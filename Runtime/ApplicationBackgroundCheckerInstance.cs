using UnityEngine;

namespace Kogane.Internal
{
    /// <summary>
    /// アプリケーションがバックグラウンドに移動したか、バックグラウンドから復帰したかを検知するためのコンポーネント
    /// </summary>
    internal sealed class ApplicationBackgroundCheckerInstance : MonoBehaviour
    {
        //================================================================================
        // 変数
        //================================================================================
        private bool? m_isBackground;

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// アプリケーションがフォーカスされた、もしくはフォーカスを失った時に呼び出されます
        /// </summary>
        private void OnApplicationFocus( bool hasFocus )
        {
            OnChangedState( !hasFocus );
        }

        /// <summary>
        /// アプリケーションが一時停止した、もしくは再開した時に呼び出されます
        /// </summary>
        private void OnApplicationPause( bool pauseStatus )
        {
            OnChangedState( pauseStatus );
        }

        /// <summary>
        /// アプリケーションが終了した時に呼び出されます
        /// </summary>
        private void OnApplicationQuit()
        {
            OnChangedState( true );
        }

        /// <summary>
        /// ステートが変化した時に呼び出されます
        /// </summary>
        private void OnChangedState( bool isBackground )
        {
            if ( m_isBackground == isBackground ) return;
            m_isBackground = isBackground;
            ApplicationBackgroundChecker.CallOnChanged( isBackground );
        }

        //================================================================================
        // 関数(static)
        //================================================================================
        /// <summary>
        /// ゲーム起動時に呼び出されます
        /// </summary>
        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
        private static void RuntimeInitializeOnLoadMethodBeforeSceneLoad()
        {
            var gameObject = new GameObject( nameof( ApplicationBackgroundCheckerInstance ) );
            DontDestroyOnLoad( gameObject );
            gameObject.AddComponent<ApplicationBackgroundCheckerInstance>();
        }
    }
}