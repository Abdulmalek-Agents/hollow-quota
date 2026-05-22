# 📜 Game Design Document — Hollow Quota

## 1. High-concept

The Holding Company hires 'Reclaimers' to retrieve cursed objects from haunted locations. You and 1-3 friends drop in, hit a quota in dollars, and escape before something hunts you. Fail the quota = fired (deleted save). Three strikes = the Company forgets you ever existed.

**Fantasy:** 'I'm the unprepared employee of a cosmic-horror corporation.'

**Emotional journey:** Bravado → dread → panic → desperate triumph or shared catastrophe → shared laughter.

**Pillars:**
1. **Streamer-bait social.** Proximity voice chat is non-negotiable.
2. **Punishing but funny.** Failure must be entertaining.
3. **Director-driven variance.** Claude AI Director makes every run feel different.

## 2. Core game loop

`Lobby → Pick location → Drop in → Loot → Avoid monster → Reach extraction → Sell loot → Quota or fired`

## 3. Player verbs

| Verb | Input | Notes |
|---|---|---|
| Move / sprint | WASD / Shift | Sprint costs stamina |
| Crouch | Ctrl | Reduces noise radius |
| Pick up / drop | E | Heavy items slow you |
| Flashlight | F | Drains battery |
| Radio | V | Speak to AI Director (Claude) |
| Proximity voice | Always on | Hear teammates spatially |
| Throw flare | Q | One-use ward |

## 4. Loot economy

| Item | Value range | Rarity |
|---|---|---|
| Pocket watch (cursed) | $80–$200 | Common |
| Photo frame (haunted) | $50–$150 | Common |
| Cursed doll | $300–$800 | Rare |
| Family heirloom | $500–$1200 | Rare |
| Sealed grimoire | $2,000–$4,000 | Legendary |

Quota M1: $1,500.

## 5. Mission structure (6 locations)

| # | Location | Monster archetype | Quota |
|---|---|---|---|
| **1** | Pilkin Manor (Victorian estate) | The Listener (sound-tracking) | $1,500 |
| 2 | Saint Hallow's Hospital (abandoned) | The Bleeder | $2,500 |
| 3 | Drowned Cathedral (waterlogged) | The Quiet Sister (whispers) | $4,000 |
| 4 | Frostward Asylum (snow-blocked) | The Stalker (mimicry) | $6,000 |
| 5 | Hollow Foundry (steampunk) | The Engine (machine-themed) | $9,000 |
| 6 | The Below (cave system) | The Brood (multiple small) | $13,000 |

Progressive difficulty: quota grows, monsters gain abilities, maps darken.

## 6. Mission 1 — *Pilkin Manor*

**Duration:** 12–20 min. **Players:** 1–4.

**Flow:**
1. Lobby → host picks Pilkin Manor.
2. Cinematic van approach (Cutscene Engine).
3. Players spawn at gate. Director gives radio briefing (Claude AI, 1–3 sentences).
4. Players enter; The Listener spawns at random point.
5. 10 loot items scattered (target $1,500).
6. Extraction zone activates after 8 minutes regardless.
7. Players must reach extraction with loot before timer or monster catches.

**Objectives (data-driven):**
- `m1_collect_quota` (Custom, value tracked separately)
- `m1_reach_extraction` (ReachLocation, 1)
- `m1_survive` (Survive, 1)
- `m1_optional_find_grimoire` (CollectItems, 1, optional)

## 7. The Listener (monster M1)

- Spawns at one of 12 random nodes.
- Hears player voice over proximity chat, footsteps, and flashlight clicks.
- Wanders quietly until it 'pings' a sound — then sprints toward last heard point for 5 seconds.
- Catching = grab animation → player downed; teammates can revive.
- Two players downed in same run = mission fails for all.

## 8. AI Director (Claude) on the radio

Every 60–90 seconds, the Director crackles in on the radio with a short comment (1–2 sentences). Topics:
- Mocking specific player events ('I see Sarah just fell down the stairs again.').
- Goading risk-taking ('Quota at $400. Try harder, Reclaimer.').
- Cryptic foreshadowing of monster movement.
- Praising rare successful loot ('A grimoire? You may live.').

Full spec in `docs/05_AI_COPILOT_INTEGRATION.md`.

## 9. UI

- Heat UI base.
- HUD: stamina, battery, loot value carried, team status.
- Radio overlay (taunt-feed) with stream-typed Director lines.

## 10. Audio

- Horror Bundle SFX = 95% of needs (300+ sounds covering monster, ambient, footsteps).
- Music: minimal; rely on tension stings.

## 11. Accessibility

- Subtitled radio + monster audio cues.
- Colourblind palette for loot value display.
- Voice-chat mute, push-to-talk, voice activity options.
- 'Director text-only' fallback if voice synthesis disabled.

## 12. Cut-list

1. Frostward Asylum (M4) deferred to post-launch DLC.
2. The Brood multi-monster system simplified to single.
3. Voice synthesis for Director — ship text-only first.

**Never cut:** Pilkin Manor, The Listener, Director radio.

✅ **Approved.**
