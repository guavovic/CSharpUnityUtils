using System;
using UnityEditor;
using UnityEngine;

namespace GV.Extensions
{
    public static class UnityExtensions
    {
        /// <summary>
        /// Modifica o método Invoke do Unity para aceitar um parâmetro e um tempo de delay.
        /// Chame o método usando "this.InvokeWithParameter(...)".
        /// </summary>
        /// <param name="method">O método a ser invocado.</param>
        /// <param name="parameter">O parâmetro a ser passado para o método.</param>
        /// <param name="time">O tempo de delay antes de chamar o método.</param>
        public static void InvokeWithParameter(this MonoBehaviour monoBehaviour, Action<object> method, object parameter, float time)
        {
            monoBehaviour.Invoke(method.Method.Name, time);
            monoBehaviour.StartCoroutine(InvokeMethodWithDelay(method, parameter, time));
        }

        private static System.Collections.IEnumerator InvokeMethodWithDelay(Action<object> method, object parameter, float time)
        {
            yield return new WaitForSeconds(time);
            method(parameter);
        }

        /// <summary>
        /// Encontra um objeto na cena atual do tipo especificado.
        /// </summary>
        /// <typeparam name="T">O tipo do objeto que está sendo procurado.</typeparam>
        /// <param name="objectEnable">Define se o objeto deve estar habilitado para ser achado.</param>
        /// <returns>O objeto encontrado do tipo especificado, ou null se não for encontrado.</returns>
        public static T FindObjectOfType<T>(this MonoBehaviour monoBehaviour, bool objectEnable = false) where T : MonoBehaviour
        {
            T result = UnityEngine.Object.FindObjectOfType<T>(objectEnable);

            if (result == null)
                Debug.LogWarning($"Objeto do tipo {typeof(T)} não foi encontrado na cena.");

            return result;
        }

        /// <summary>
        /// Remove os componentes especificados.
        /// </summary>
        /// <param name="components">Os componentes que serão removidos.</param>
        public static void RemoveComponents(this MonoBehaviour monoBehaviour, params UnityEngine.Object[][] components)
        {
            foreach (var componentArray in components)
            {
                foreach (var component in componentArray)
                {
                    if (component != null)
                    {
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.delayCall += () => UnityEngine.Object.DestroyImmediate(component, true);
#else
                        UnityEngine.Object.Destroy(component);
#endif
                    }
                }
            }
        }

        /// <summary>
        /// Registra uma mensagem no console do Unity com formatação opcional de cor.
        /// </summary>
        /// <param name="message">A mensagem a ser registrada.</param>
        /// <param name="color">A cor da mensagem (aplicável apenas no Unity Editor).</param>
        public static void DebugLogColored(string message, Color color, MonoBehaviour monoBehaviour = null)
        {
            message = StringUtilities.FormatFieldName(message); // Opcional
            string colorRGB = ColorUtility.ToHtmlStringRGB(color);
#if UNITY_EDITOR
        Debug.Log($"<color=#{colorRGB}><b>{message}</b></color>");
#else
            Debug.Log(message);
#endif
        }
    }
}