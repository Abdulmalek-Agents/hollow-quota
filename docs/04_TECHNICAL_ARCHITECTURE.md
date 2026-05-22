# 🧱 Technical Architecture — Hollow Quota

> v0.2: runtime LLM removed. Director draws from event-specific `LineBankSO` pools.
> v0.2.1: Unity 6 LTS (6000.4.4f1) target.

## 1. Stack

| Layer | Choice |
|---|---|
| Engine | Unity **6 LTS (6000.4.4f1)** |
| Render | **URP 17.x** |
| Networking | Photon PUN 2 (template), Photon Voice 2 (proximity chat) |
| Scripting | C# 9, .NET Standard 2.1 |
| Async loading | Addressables |
| Save | JsonUtility → persistentDataPath |
| Dialogue | Hand-authored `LineBankSO` pools (Director events) |
| Camera | Cinemachine 3.x |
| Source control | Git + LFS |

## 2. Scripts (`Assets/_Project/Scripts/`)

```
Core/  (shared)
  GameBootstrap, ServiceLocator, SceneLoader, Mission/, Save/, Audio/, Checkpoint/, Events/, Pooling/
Dialogue/    DialogueNodeSO, LineBankSO, ScriptedDialogueService
UI/    MainMenuController, HUDController, RadioOverlay
Gameplay/
  Player/      ReclaimerPlayer, ReclaimerHealth, PlayerInteractor, FlashlightController
  Monster/     ListenerMonster, MonsterAIBase, SoundDetector
  Loot/        LootItem, LootItemDataSO, QuotaSystem
  Director/    RadioDirector  (consumes LineBankSO per event type)
  Mission01/   Mission01Director
```

## 3. Scenes

| Scene | Build idx |
|---|---|
| Bootstrap | 0 |
| MainMenu + Lobby | 1 |
| Mission01_PilkinManor | 2 |
| Mission02..06 | 3-7 |

## 4. Networking model

- **Photon PUN 2 master-client authority** for monster AI and loot spawn.
- Player movement is owner-authoritative (anti-cheat is light — it's a co-op game).
- Loot picked up is an RPC; quota total syncs as a Photon hashtable property.
- **Director lines:** the master client picks a line from the appropriate `LineBankSO` and broadcasts the chosen index via RPC so every client renders the same line + (optional) voice-over clip.

## 5. Listener Monster state machine

`Wander → (heard sound) Pursue (5s) → (lost player) Investigate (5s) → Wander`

SoundDetector listens to:
- Player footstep events (broadcast via Photon)
- Voice activity from Photon Voice (volume threshold)
- Flashlight click (audio event)

## 6. Quota system

- ScriptableObject `LootItemDataSO` defines value range + rarity.
- At Mission start, `QuotaSystem` rolls values within range, spawns 10–15 items.
- Players carrying loot increment shared `currentQuota`.
- At extraction zone, items sold = quota crystallised.

## 7. Unity 6 (6000.4.4f1) compatibility notes

- **URP** upgraded from 14.x to 17.x — Render Pipeline Converter handles Unity 2022–era assets.
- **Photon PUN 2** has official Unity 6 support; Photon Voice 2 likewise (update to the latest package from the Photon dashboard after import).
- **Cinemachine 3.x** — first-person camera uses `CinemachineCamera` + `CinemachineHardLockToTarget` (Hollow Quota is first-person).
- **Render Graph API** opt-in.
- **NavMesh** + **TextMeshPro** + **Addressables** unchanged.

## 8. Scalability

- Mission 2 = new scene + new MissionData + new MonsterAI variant (data-driven).
- New monster = new MonsterAIBase subclass + EnemyDataSO.
- New Director event = add a `LineBankSO` field on `RadioDirector` + author the bank.
- Save format kv preserves older fields.
- Internet outage breaks game? ❌ No (LAN-friendly; Photon LAN mode also works).

## 9. Performance budget (60 fps on RTX 2060, 4 players)

- Draw calls < 1,000 per client
- Triangles < 1.8M visible
- Photon messages < 50/sec per client
- Memory < 1.5 GB

## 10. CI later.
