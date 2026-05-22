# Changelog — Hollow Quota

## [v0.2-mission1-no-runtime-ai] — Removed runtime LLM dependencies

### Changed
- **Critic & Review Board re-review (Cycle 4):** AI is now a development-workflow tool,
  not a runtime gameplay feature. The shipping game no longer calls any LLM at runtime.
- `RadioDirector` rewritten to pick from event-specific `LineBankSO` pools
  (`idleBank`, `downedBank`, `bigLootBank`, `quotaHitBank`, `huddleBank`). Photon
  master-client broadcast pattern preserved.
- `GameBootstrap.cs` registers `IScriptedDialogueService` instead of `IAICopilotService`.
- `docs/05_AI_COPILOT_INTEGRATION.md` replaced with `docs/05_AI_ASSISTED_DEVELOPMENT.md`.
- README updated to drop runtime-AI claims.

### Removed
- `Assets/_Project/Scripts/AI/` (ClaudeCopilotService, AICopilotPersonaSO)
- `server/copilot-proxy/` (Node proxy)

---

## [v0.1-mission1-skeleton] — Initial scaffolding

### Added
- Concept locked through 3 Critic Review Board cycles
- GDD v1.0, Asset Plan, Tech Architecture, AI integration doc, Unity setup guide
- Photon PUN 2 multiplayer foundation
- Hollow Quota scripts (Director, Loot, Monster, Player)
- Claude AI Director plan + Node proxy *(both removed in v0.2)*
