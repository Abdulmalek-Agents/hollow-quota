# 🎨 Asset Plan — Hollow Quota

## 1. Existing inventory

| Asset | Used for | Critical |
|---|---|---|
| **Horror Multiplayer Game Template** ($59.99) | Photon networking, lobby, framework | 🔴 Yes |
| **Urban Abandoned District** ($50) | Pilkin Manor exterior approach | 🔴 Yes |
| **Stylized Dungeons** ($50) | Manor cellar, M3 cathedral interior | 🔴 Yes |
| **Medieval Village Megapack** | Manor exterior + outbuildings | 🟡 Helpful |
| **City Characters Modular Animated** ($259) | Reclaimer player + civilian victim 'cursed mannequin' loot | 🔴 Yes |
| **Fantasy Monsters Bundle** ($99.50) | The Listener (re-skin Demon), other monsters | 🔴 Yes |
| **Eyes Animator** ($11.99) | Monster procedural eye behaviour | 🟡 Helpful |
| **Horror Bundle SFX** ($49.99) | Ambient, monster, footsteps, stingers | 🔴 Yes |
| **Volumetric Blood Fluids** ($30) | Down state + monster aftermath | 🟡 Helpful |
| **Screenspace VFX** ($30) | Low-HP vignette, haunting flash | 🔴 Yes |
| **Lumen Stylized Light FX 2** ($35) | Flashlight cone + key light shafts | 🔴 Yes |
| **VoluSmokeFX** ($25) | Atmospheric fog/smoke pockets | 🟡 Helpful |
| **Heat UI** ($69.99) | Main menu, lobby, HUD | 🔴 Yes |
| **Cutscene Engine** ($35) | Van approach intro, ending sting | 🔴 Yes |

**Inventory value applied: ~$800 across 14 assets.**

## 2. Gap analysis

| Gap | Suggested | Cost |
|---|---|---|
| Proximity voice chat | **Photon Voice 2** (free tier; Asset Store) | $0–60 |
| OST (light, tension stings, 6 cues) | Commission Fiverr | $200 |
| Director voice synthesis (optional) | ElevenLabs API + cache | API cost |

## 3. Folder organisation

Standard `_Project/Art/{Characters,Environment,VFX,UI}`, `_Project/Audio`, etc.

## 4. Performance tweaks

- Photon view sync at 10Hz for non-critical objects.
- All monsters in Object Pool.
- Horror Bundle SFX clips compressed to OGG at 96kbps.
- VoluSmokeFX limited to 8 active volumes per scene.

## 5. Licence ✅ — EULA-compliant; no binaries in repo.

## 6. Checklist

- [ ] Import Horror Multiplayer Template; verify lobby + matchmaking works
- [ ] Integrate Photon Voice 2
- [ ] Build Player_Reclaimer.prefab
- [ ] Build Listener_Monster.prefab with NavMesh + state machine
- [ ] Build 5 loot item prefabs with LootItemData
- [ ] Author Pilkin Manor scene
- [ ] Wire AI Director radio component to Claude proxy
