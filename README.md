# 👻 Hollow Quota

> 4-player co-op horror extraction. You and your friends are *Reclaimers* — dispatched into haunted locations by The Holding Company to retrieve cursed objects worth precise dollar amounts. Hit the quota or get fired. (Permanently.)

| | |
|---|---|
| **Genre** | Co-op Horror Extraction (Phasmophobia / Lethal Company / REPO lane) |
| **Platforms** | PC (Steam) primary |
| **Engine** | Unity 2022.3 LTS + URP + Photon PUN 2 |
| **Target frame-rate** | 60 fps on RTX 2060 |
| **Mission 1 scope** | 'The Pilkin Manor' — first haunted house, 1 monster, $1500 quota |
| **Designed for** | 6 missions (different haunted locations) |
| **AI co-pilot** | Claude-powered 'Director' — procedural taunts via radio, dynamic objective banter |

## Why this game

| Signal | Source |
|---|---|
| REPO reached 19.6M players — co-op horror extraction is exploding | R.E.P.O., one of the year's biggest surprises, has reached 19.6 million players |
| REPO storming Twitch + Discord | Creative monster design, high-stakes gameplay, unpredictable missions — blowing up across Twitch and Discord servers |
| Lethal Company solo-dev cleared millions; pattern is repeatable | Streamer-friendly extraction loop |
| Asset Store ships a 'Horror Multiplayer Game Template' — perfect foundation | ~80% coverage from one purchase |

Details in `docs/01_IDEATION_AND_TRENDS.md`.

## Quick start

1. Read `docs/07_UNITY_SETUP_GUIDE.md`.
2. Unity 2022.3 LTS URP project; copy `Assets/_Project/`.
3. Import: **Horror Multiplayer Game Template** (Photon PUN 2 backbone), Urban Abandoned District, Stylized Dungeons, Fantasy Monsters Bundle (re-skinned ghosts), Horror Bundle SFX, Volumetric Blood Fluids, Screenspace VFX, Lumen FX 2, Eyes Animator, Heat UI, Cutscene Engine, City Characters — all already in your inventory.
4. `cd server/copilot-proxy && npm install && npm run dev`.
5. Open `Scenes/Bootstrap.unity`.

## Status

| Stage | Status |
|---|---|
| Concept locked (3 critic cycles) | ✅ |
| GDD v1.0 approved | ✅ |
| Architecture & scripts | ✅ |
| Mission 1 vertical slice authored | ⏳ requires asset import |
| Missions 2–6 outlined | ✅ data-driven |
