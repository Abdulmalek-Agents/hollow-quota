# 🛠️ Unity Setup Guide — Hollow Quota

> **v0.2.1: Unity 6 LTS (6000.4.4f1) target. No proxy server, no API key, no internet config required.**

## Prerequisites
- Unity Hub + Unity **6 LTS (6000.4.4f1)** with Windows IL2CPP module
- Inventix Asset Store account holding the assets in `03_ASSET_PLAN.md`
- Photon Cloud account (free tier OK — sign up at photonengine.com)

## Step 1 — New Unity project
Unity Hub → select Editor **6000.4.4f1** → template **Universal 3D** → `HollowQuota`.

## Step 2 — Drop repo in
```bash
git clone https://github.com/Abdulmalek-Agents/hollow-quota.git
```
Copy `Assets/_Project/` + `.gitignore`.

## Step 3 — Render pipeline + lighting
Graphics URP 17.x + Linear color space + bake atmospheric darkness.

## Step 4 — Import (in order)
1. Heat UI
2. **Horror Multiplayer Game Template** (pulls in Photon PUN 2 — follow its README to set App ID)
3. **Photon Voice 2** (free Asset Store; proximity chat)
4. Urban Abandoned District
5. Stylized Dungeons
6. Medieval Village Megapack
7. City Characters Modular Animated
8. Fantasy Monsters Bundle
9. Eyes Animator
10. Horror Bundle SFX
11. Volumetric Blood Fluids
12. Screenspace VFX
13. Lumen FX 2
14. VoluSmokeFX
15. Cutscene Engine

After import: Photon Wizard → paste your Photon App ID.

> **Unity 6 note:** if any package imports with pink materials, run **Edit → Rendering → Render Pipeline Converter → Built-in to URP**. Photon PUN 2 / Voice 2 are Unity-6-compatible — update to the latest version from the Photon dashboard if needed.

## Step 5 — Bootstrap
New scene `Scenes/Bootstrap.unity` → `[Game]` with `GameBootstrap`. Build idx 0.

## Step 6 — MainMenu/Lobby
Use Horror Multiplayer Template's lobby prefab as your starting point. Wrap in Heat UI for visual polish. Build idx 1.

## Step 7 — Mission 1 — Pilkin Manor
1. New scene `Scenes/Mission01_PilkinManor.unity`.
2. Drop Urban Abandoned District manor + Medieval Village outbuildings.
3. Stylized Dungeons cellar inside the manor.
4. NavMesh bake the whole interior.
5. Player_Reclaimer prefab spawn points (4 spawn anchors at the van).
6. Listener_Monster prefab at 12 random spawn nodes (script chooses one at runtime).
7. 10–15 LootItem prefabs scattered with weighted random rarity.
8. ExtractionZone trigger near the van.
9. `[Mission01Director]` + `RadioDirector` + `QuotaSystem` GameObjects.
10. Create `MissionData_M01.asset` with 4 objectives (GDD §6).

Build idx 2.

## Step 8 — Author the Director line banks

1. **Create → Inventix → Dialogue → Line Bank** five times:
   - `LineBank_Director_Idle.asset` (40 generic mocking lines, ~60–90s cadence)
   - `LineBank_Director_Downed.asset` (30 lines; use `{name}` token for player name)
   - `LineBank_Director_BigLoot.asset` (25 lines)
   - `LineBank_Director_QuotaHit.asset` (15 begrudging-praise lines)
   - `LineBank_Director_Huddle.asset` (20 lines)
2. Drag each into the corresponding field on `RadioDirector`.
3. Optional: drop wav clips into the `voiceOver` array (parallel to `lines`).

Voice guide: dry, corporate, mildly menacing. Use "asset recovery", "productivity metrics", "performance review". Never give strategic hints.

## Step 9 — Playtest
Host a private Photon room with 1–3 friends. Confirm:
- Lobby + room creation/join works (template behaviour)
- Loot syncs to all clients
- Monster AI is master-client authoritative
- Director lines fire on Idle interval + on downed/quotahit events on all clients simultaneously
- Extraction zone triggers correctly

## Troubleshooting

| Symptom | Fix |
|---|---|
| Photon connect fails | App ID not set in Photon Wizard |
| Voice chat silent | Photon Voice 2 not initialised; check OnEnable on its component |
| Director silent | Master client only — verify `isMasterClient` flag and that LineBanks are assigned |
| Director fires different lines on each client | RPC broadcasting the chosen index, not the string — verify RadioDirector.FireLine override |
| Pink materials | Render Pipeline Converter (Built-in → URP) |
| Monster doesn't sync | Check PhotonView on Listener_Monster prefab |
| Loot duplicates on join | LootItem prefab must use OnPhotonInstantiate, not Instantiate |

## After M1
Tag `v0.2.1-mission1-playable`. Each subsequent mission: new MissionData asset + new scene + new MonsterAIBase subclass.
