# Changelog — Hollow Quota

## [v0.2.1] — Unity 6 LTS target + v0.2 doc alignment

### Changed
- Engine target bumped from Unity 2022.3 LTS → **Unity 6 LTS (6000.4.4f1)**.
- URP from 14.x → 17.x; Cinemachine references updated to 3.x.
- `docs/04_TECHNICAL_ARCHITECTURE.md` rewritten to drop residual v0.1 references to `ClaudeCopilotService` / `AICopilotPersonaSO`; new §7 "Unity 6 compatibility notes"; Director networking section now references LineBank RPC pattern.
- `docs/07_UNITY_SETUP_GUIDE.md` rewritten to v0.2 (no AI proxy / API-key steps; LineBank authoring step); Unity 6 project flow; Photon-6 compatibility note.
- `README.md` Engine row + status table.

No gameplay code changes — v0.2 C# is fully forward-compatible with Unity 6.

---

## [v0.2-mission1-no-runtime-ai] — Removed runtime LLM dependencies

### Changed
- **Critic & Review Board re-review (Cycle 4):** AI is now a development-workflow tool,
  not a runtime gameplay feature. The shipping game no longer calls any LLM at runtime.
- `RadioDirector` rewritten to pick from event-specific `LineBankSO` pools.
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
