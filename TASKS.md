# Azure Developer Associate: Rapid Recovery Checklist 🚀

These mini-demos target your weakest areas:  
**📉 Application Insights**, **📨 Message-based solutions**, **⚡ Azure Functions**

## 🔧 Prerequisites
- [x] Existing deployed [Event Grid Viewer](https://github.com/zygisau/my-azure-event-grid-viewer)
- [x] Azure Storage Account with Event Grid events enabled
- [ ] Azure Service Bus namespace created
- [ ] App Registration for OAuth2 (optional for later)

---

## ✅ PART 1: Blob Events + Event Grid Viewer
**Goal:** Trigger your Event Grid Viewer on blob upload.

- [x] Enable `BlobCreated` event on a container
- [x] Add an Event Subscription to your deployed Event Grid Viewer
- [x] Upload a test blob and confirm event appears in viewer

---

## ✅ PART 2: Service Bus + Console Sender
**Goal:** Send messages using Managed Identity

- [x] Assign **System-Assigned Managed Identity** to console app or Function App
- [x] Give the identity `Azure Service Bus Data Sender` on the queue
- [x] Use `DefaultAzureCredential` to send a message to the queue
- [x] Confirm it lands in the queue

---

## ✅ PART 3: Function App with Service Bus Trigger
**Goal:** Read queue messages and output to Blob Storage

- [x] Create a Function App with a **Service Bus trigger**
- [x] Add an **output binding to Blob Storage**
- [x] Use a managed identity to authenticate (no connection strings)
- [x] Test end-to-end: send → process → store blob

---

## ✅ PART 4: Application Insights in Action
**Goal:** Monitor real-time logs and dependencies

- [x] Enable **Application Insights** on your Function App or console app
- [x] Add `ILogger` or `TelemetryClient.TrackEvent()` calls
- [x] View:
  - [x] **Live Metrics Stream**
  - [x] **Traces and logs**
  - [x] **Failures/Dependencies** (if using HttpClient or similar)

---

## ✅ PART 5: Shared Access Signatures (SAS)
**Goal:** Create limited-time access links

- [ ] Generate a SAS token with read-only blob access (1-hour expiry)
- [ ] Access the blob using SAS via browser or curl
- [ ] Optional: try a **Service SAS** vs **Account SAS**

---

## ✅ OPTIONALS (Bonus Confidence Boosters)
### Feature Flags (via App Configuration)
- [ ] Set up a flag in App Configuration
- [ ] Reference it in a .NET app using `Azure.Data.AppConfiguration`

### Durable Functions (Fan-Out Fan-In)
- [ ] Create an orchestrator function that triggers multiple blob writes
- [ ] Use it to understand control flow, state persistence

### OAuth2 with API Management
- [ ] Protect Event Grid Viewer with OAuth2 via APIM inbound policy
- [ ] Test calling the API with and without tokens

---

## 📌 Summary + Exam Mental Tricks
After each demo, ask yourself:
- Can I explain this concept to a friend?
- Where would this appear in a real architecture diagram?

Use **mnemonics** or **drawn diagrams** to lock in:
- App Insights flow: `App → SDK → AI SDK → AI Resource`
- Message processing: `Producer → Service Bus → Triggered Processor → Result`
- Identity: `DefaultAzureCredential → Tries MSI → CLI → VSCode → EnvVars`

---

## 🧠 Last-Minute Strategy
- Prioritize **comprehension** over memorization
- Review **RBAC roles**, **trigger types**, **App Insights UI**
- Sleep well — brain needs rest to convert info into memory

You've got this. 💪
