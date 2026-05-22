# 🤖 Claude AI Director — Hollow Quota

## 1. The pitch

Every 60–90 seconds the radio crackles. The Director (a Claude-powered entity inside The Holding Company HQ) makes a short, mocking, in-character comment about what just happened.

This is the differentiator. REPO has zany monsters; we have a writer that **mocks you by name**.

## 2. Trigger events

| Trigger | Director's job |
|---|---|
| Player downed | Mock with their name |
| Loot value crosses $500 | Praise |
| Monster pings player | Build tension |
| All players in same room for >15s | Comment on huddling |
| Player spends 60s in lobby | Encourage / shame |
| Quota reached | Begrudging applause |

## 3. Master-client only call pattern

Only the Photon master client calls Claude. The reply is RPC-broadcast to all clients so everyone hears the same Director line. Saves token cost and keeps the experience identical.

## 4. Director persona

```
You are The Director — a corporate-horror voice on the company radio in the co-op horror extraction game 'Hollow Quota'.

Voice: drily corporate, mildly menacing, occasionally amused by employee suffering. Refer to players as 'Reclaimer' or by name when given.

The Holding Company hires expendable Reclaimers to retrieve cursed objects. You manage them remotely. You are not their friend.

Rules:
- Reply in 1–2 short sentences.
- Never break character or reference being an AI/LLM.
- Lean into corporate jargon: 'asset recovery', 'productivity metrics', 'performance review'.
- Mock failure; faint praise for success.
- Never give real strategic hints. (Lethal Company-style — you do not help them survive.)
- Avoid modern slang.
```

## 5. Event payload to Claude

The master client sends a structured event context plus the persona:
```
Context: Player SARAH was just downed by The Listener in the conservatory. Team carrying $750/$1,500 quota. 6 minutes left.
```
Claude returns one line. Stream into RadioOverlay UI for all clients.

## 6. Cost projection (4 players, 1 master, 12-min mission)

- ~10 director lines per mission × 200 tokens each
- ~2,000 tokens per match per host
- ~$0.003 per match

**1k matches/day across player base = $3/day.** Trivial.

## 7. Safety

- Pre-prompt steers Director away from real-world taunting, slurs, or PII.
- Player names sent to Claude are in-game IDs; real Steam usernames are not transmitted.
- max_tokens=128.
- Falls back to a 30-line scripted Director script if proxy unreachable.

## 8. Tone-control safeguard

If a generated line trips a profanity / outrage filter, the master client falls back silently to a scripted line. Players never see broken UX.
