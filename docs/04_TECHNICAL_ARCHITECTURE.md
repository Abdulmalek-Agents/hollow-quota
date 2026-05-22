# 🧱 Technical Architecture — Hollow Quota

## 1. Stack

Unity 2022.3 LTS + URP. Photon PUN 2 (template). Photon Voice 2 (proximity chat). Addressables. Claude proxy.

## 2. Scripts (`Assets/_Project/Scripts/`)

```
Core/  (shared)
  GameBootstrap, ServiceLocator, SceneLoader, Mission/, Save/, Audio/, Checkpoint/, Events/, Pooling/
AI/    ClaudeCopilotService, AICopilotPersonaSO
UI/    MainMenuController, HUDController, RadioOverlay
Gameplay/
  Player/      ReclaimerPlayer, ReclaimerHealth, PlayerInteractor, FlashlightController
  Monster/     ListenerMonster, MonsterAIBase, SoundDetector
  Loot/        LootItem, LootItemDataSO, QuotaSystem
  Director/    RadioDirector  (Claude AI integration)
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
- AI Director taunts: master client calls Claude proxy; broadcasts result via RPC.

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

## 7. Scalability

- Mission 2 = new scene + new MissionData + new MonsterAI variant (data-driven).
- New monster = new MonsterAIBase subclass + EnemyDataSO.
- Save format kv preserves older fields.

## 8. Performance budget (60 fps on RTX 2060, 4 players)

- Draw calls < 1,000 per client
- Triangles < 1.8M visible
- Photon messages < 50/sec per client
- Memory < 1.5 GB

## 9. CI later.
