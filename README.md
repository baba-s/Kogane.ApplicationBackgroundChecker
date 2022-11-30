# Kogane Application Background Checker

アプリケーションがバックグラウンドに移動したか、バックグラウンドから復帰したかを検知できるクラス

## 使用例

```csharp
ApplicationBackgroundChecker.OnChanged = isBackground => Debug.Log( isBackground );
```