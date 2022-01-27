// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Error List, point to "Suppress Message(s)", and click 
// "In Project Suppression File".
// You do not need to add suppressions to this file manually.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes", Scope = "type", Target = "CC.Business.ProfileManager.Core.CribisComX.ProfileKey")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes", Scope = "type", Target = "CC.Business.ProfileManager.Core.CribisComX.ExpiryData")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "CC.Business.ProfileManager.Core.CribisComX.ProfileStore`1.#.cctor()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "CC.Business.ProfileManager.Core.CribisComX.ProfileManager`1.#.cctor()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "System.Guid", Scope = "member", Target = "CC.Business.ProfileManager.Core.CribisComX.DBHelper.#GetProfile(System.String,CC.Business.ProfileManager.Core.CribisComX.ProfileKey)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Console.WriteLine(System.String,System.Object)", Scope = "member", Target = "CC.Business.ProfileManager.Core.CribisComX.ProfileManager`1.#UpdateProfilationProfile(System.String,System.String,System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Console.WriteLine(System.String,System.Object)", Scope = "member", Target = "CC.Business.ProfileManager.Core.CribisComX.ProfileManager`1.#timer_Expired(CC.Business.ProfileManager.Core.CribisComX.ProfileKey)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Console.WriteLine(System.String,System.Object)", Scope = "member", Target = "CC.Business.ProfileManager.Core.CribisComX.ProfileManager`1.#SetProfilationProfile(System.String,System.String,System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Console.WriteLine(System.String,System.Object)", Scope = "member", Target = "CC.Business.ProfileManager.Core.CribisComX.ProfileManager`1.#SetProfilationOverride(System.String,System.String,System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Console.WriteLine(System.String,System.Object)", Scope = "member", Target = "CC.Business.ProfileManager.Core.CribisComX.ProfileManager`1.#DeleteProfilation(System.String,System.String,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Scope = "type", Target = "CC.Business.ProfileManager.Core.CribisComX.ProfileTimer")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Scope = "member", Target = "CC.Business.ProfileManager.Core.CribisComX.ProfileTimer.#Dispose()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Scope = "member", Target = "CC.Business.ProfileManager.Core.CribisComX.ProfileTimer.#Finalize()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Scope = "member", Target = "CC.Business.ProfileManager.Core.CribisComX.ProfileTimer.#Expired")]
