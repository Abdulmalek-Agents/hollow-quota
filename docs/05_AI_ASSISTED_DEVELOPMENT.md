# 🤖 AI-Assisted Development — Hollow Quota

> **Important:** AI is a **development tool**, not a runtime feature.
> No part of the shipping game calls an LLM at runtime. The Director's mocking
> radio lines are hand-authored into `LineBankSO` pools (one per event type)
> and broadcast deterministically by the Photon master client to all peers.
> Claude (via Claude Code and Claude Agents) is used by the studio to speed up
> design, code, asset wiring, dialogue writing, and QA — never by the player.

## 1. What the studio uses Claude for

| Phase | What Claude does | What humans do |
|---|---|---|
| Concept & trend research | Pulls REPO / Lethal Company / Phasmo signals | Final greenlight |
| GDD authoring | Drafts Mission 1–6 haunted-location layouts, monster behaviour, quota tuning | Pillar checks |
| Code generation | Produces Photon hooks, ScriptableObjects, Director loop, Loot system, Monster AI | Senior dev review + Unity wiring |
| Director-line writing | Drafts 30–60 lines per event-bank (idle, downed, big loot, quota hit, huddle) in the dry corporate-horror voice | Writers polish |
| QA & playtesting scripts | Authors 4-player co-op test sheets, edge-case bug repros | Manual play |

## 2. Why we removed runtime LLM features (v0.1 → v0.2)

| Concern | v0.1 (runtime Director LLM) | v0.2 (hand-authored banks) |
|---|---|---|
| Tone consistency in a 4-player horror game | LLM may break corporate-horror register | 100% authored lines, voice-actable |
| Internet dependency in extraction games | Phones home every minute | Fully offline; LAN-friendly |
| Per-DAU cost across 4-player parties | ~$3/day per 1k matches | $0 |
| Steam policy disclosure | Required | None |
| Latency mid-mission | 600–2,000 ms | Instant |
| QA repro across 4 clients | Hard | Deterministic |
| Voice-over recording (later) | Impossible (lines are runtime-generated) | Trivial — fixed line set |

## 3. How Claude shows up in the dev workflow

1. **Plan** — GDD drafts.
2. **Code** — Claude Code generates Unity C# directly into branch PRs.
3. **Review** — Critic & Review Board persona panel audits.
4. **Wire** — Click-by-click Unity Editor instructions.
5. **Author content** — Director lines, monster lore, loot card text.
6. **Test** — 4-player co-op test sheets.
7. **Ship** — Only the compiled game ships. No LLM at runtime.

## 4. The shipping game's dialogue stack

| Type | When | Author tool |
|---|---|---|
| `LineBankSO` | Director radio lines (per event type) | Inspector edit + Claude drafts |
| `LineBankSO` | Monster-vocalisation cues (optional) | Same |
| `DialogueNodeSO` | Optional lobby NPC briefings | Inspector edit |

## 5. Example: authoring `LineBank_Director_Downed.asset` with Claude in the loop

1. Writer asks Claude: *"Draft 40 short Director radio lines for when a Reclaimer is downed. Dry, corporate, mildly menacing. Use {name} as a token for the player's in-game name. 1–2 sentences. No real-world slurs."*
2. Claude returns 40 lines as a YAML list.
3. Writer creates `LineBank_Director_Downed.asset`, pastes lines, drags it into the `downedBank` field on `RadioDirector`.
4. Run a private match — verify lines fire on down events. **No proxy, no API key, no token cost.**

## 6. What replaced what

| v0.1 (deleted) | v0.2 (replacement) |
|---|---|
| `Persona_Director.asset` (systemPrompt) | `LineBank_Director_Idle/Downed/BigLoot/QuotaHit/Huddle.asset` |
| `AICopilotPersonaSO.cs` | (deleted) |
| `ClaudeCopilotService.cs` | `ScriptedDialogueService.cs` |
| `server/copilot-proxy/` | (deleted) |

## 7. What the user must do after cloning

1. Open Unity project per `docs/07`.
2. Buy & import asset packs per `docs/03`.
3. Drag prefabs / wire scenes per `docs/07`.
4. **No proxy server, no API key, no internet config required.**
