using System;
using UnityEngine;

namespace Kogane
{
    /// <summary>
    /// アプリケーションがバックグラウンドに移動したか、バックグラウンドから復帰したかを検知できるクラス
    /// </summary>
    public static class ApplicationBackgroundChecker
    {
        //================================================================================
        // プロパティ(static)
        //================================================================================
        public static Action<bool> OnChanged { get; set; }

        //================================================================================
        // 関数(static)
        //================================================================================
        /// <summary>
        /// ゲーム起動時に呼び出されます
        /// </summary>
        internal static void CallOnChanged( bool isBackground )
        {
            OnChanged?.Invoke( isBackground );
        }

        /// <summary>
        /// ゲーム起動時に呼び出されます
        /// </summary>
        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.SubsystemRegistration )]
        private static void RuntimeInitializeOnLoadMethodSubsystemRegistration()
        {
            OnChanged = null;
        }
    }
}