# 👻 Hollow Quota

> 4-player co-op horror extraction. You and your friends are *Reclaimers* — dispatched into haunted locations by The Holding Company to retrieve cursed objects worth precise dollar amounts. Hit the quota or get fired. (Permanently.)

| | |
|---|---|
| **Genre** | Co-op Horror Extraction (Phasmophobia / Lethal Company / REPO lane) |
| **Platforms** | PC (Steam) primary |
| **Engine** | Unity **6 LTS (6000.4.4f1)** + URP + Photon PUN 2 |
| **Target frame-rate** | 60 fps on RTX 2060 |
| **Mission 1 scope** | 'The Pilkin Manor' — first haunted house, 1 monster, $1500 quota |
| **Designed for** | 6 missions (different haunted locations) |
| **Runtime AI features** | **None** — the shipping game is fully offline (LAN-friendly). The Director draws from hand-authored line banks. |
| **AI in development** | Claude Code & Claude Agents are used by the studio. See [docs/05_AI_ASSISTED_DEVELOPMENT.md](docs/05_AI_ASSISTED_DEVELOPMENT.md). |

## Why this game

| Signal | Source |
|---|---|
| REPO reached 19.6M players — co-op horror extraction is exploding | R.E.P.O., one of the year's biggest surprises |
| REPO storming Twitch + Discord | Creative monster design, high-stakes gameplay |
| Lethal Company solo-dev cleared millions; pattern is repeatable | Streamer-friendly extraction loop |
| Asset Store ships a 'Horror Multiplayer Game Template' — perfect foundation | ~80% coverage from one purchase |

Details in `docs/01_IDEATION_AND_TRENDS.md`.

## Quick start

1. Read `docs/07_UNITY_SETUP_GUIDE.md`.
2. Unity **6 LTS (6000.4.4f1)** URP project; copy `Assets/_Project/`.
3. Import: **Horror Multiplayer Game Template** (Photon PUN 2 backbone), Urban Abandoned District, Stylized Dungeons, Fantasy Monsters Bundle (re-skinned ghosts), Horror Bundle SFX, Volumetric Blood Fluids, Screenspace VFX, Lumen FX 2, Eyes Animator, Heat UI, Cutscene Engine, City Characters — all already in your inventory.
4. Open `Scenes/Bootstrap.unity`.

> No proxy server, no API key, no internet config required.

## Status

| Stage | Status |
|---|---|
| Concept locked (3 critic cycles) | ✅ |
| GDD v1.0 approved | ✅ |
| Architecture & scripts | ✅ |
| v0.2 — runtime LLM removed, Director uses LineBanks | ✅ |
| v0.2.1 — Unity 6 LTS (6000.4.4f1) target | ✅ |
| Mission 1 vertical slice authored | ⏳ requires asset import |
| Missions 2–6 outlined | ✅ data-driven |
