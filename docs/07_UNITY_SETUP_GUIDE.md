# 🛠️ Unity Setup Guide — Hollow Quota

## Prerequisites
- Unity 2022.3.30f1 LTS + Windows IL2CPP
- Inventix Asset Store account holding the assets in `03_ASSET_PLAN.md`
- Photon Cloud account (free tier OK — sign up at photonengine.com)
- Node.js 18+ for AI proxy
- Anthropic API key

## Step 1 — New Unity project
Unity Hub → 3D (URP) Core → `HollowQuota`.

## Step 2 — Drop repo in
```bash
git clone https://github.com/Abdulmalek-Agents/hollow-quota.git
```
Copy `Assets/_Project/` + `.gitignore`.

## Step 3 — Render pipeline + lighting
Graphics URP + Linear color space + bake atmospheric darkness.

## Step 4 — Import (in order)
1. Heat UI
2. **Horror Multiplayer Game Template** (will pull in Photon PUN 2 dependency — follow its README to set App ID)
3. **Photon Voice 2** (free Asset Store; needed for proximity chat)
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

## Step 8 — AI proxy
```bash
cd server/copilot-proxy && cp .env.example .env  # set ANTHROPIC_API_KEY
npm install && npm run dev
```

## Step 9 — Director persona
Create → Inventix → AI Copilot → Persona → `Persona_Director.asset`. Paste prompt from `05_AI_COPILOT_INTEGRATION.md`.

## Step 10 — Playtest
Host a private Photon room with 1–3 friends. Confirm:
- Lobby + room creation/join works (template behaviour)
- Loot syncs to all clients
- Monster AI is master-client authoritative
- Director taunts arrive every 60–90s
- Extraction zone triggers correctly

## Troubleshooting

| Symptom | Fix |
|---|---|
| Photon connect fails | App ID not set in Photon Wizard |
| Voice chat silent | Photon Voice 2 not initialised; check OnEnable on its component |
| Director silent | Proxy not running OR you are not master client |
| Monster doesn't sync | Check PhotonView on Listener_Monster prefab |
| Loot duplicates on join | LootItem prefab must use OnPhotonInstantiate, not Instantiate |

## After M1
Tag `v0.1-mission1-playable`. Each subsequent mission: new MissionData asset + new scene + new MonsterAIBase subclass.
