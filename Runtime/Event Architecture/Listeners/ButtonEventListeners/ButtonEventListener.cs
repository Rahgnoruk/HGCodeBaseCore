using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonEventListener : MonoBehaviour
{
    [SerializeField] private Button buttonListenedTo;
    /// <summary>
    /// UnityEvent creara una lista que se puede llenar
    /// con los componentes que se quiera.
    /// </summary>
    [SerializeField] private UnityEvent response;
    private UnityAction responseCaller;

    /// <summary>
    /// NO AGREGAR ARGUMENTOS AL METODO. Si la respuesta necesita informacion, 
    /// que la obtenga de un ScriptableObjectRegistry o algo similar.
    /// </summary>
    private void OnEnable()
    {
        responseCaller += response.Invoke;
        EventListenedTo.onClick.AddListener(this.responseCaller);
    }
    private void OnDisable()
    {
        EventListenedTo.onClick.RemoveListener(this.responseCaller);
    }

    public Button EventListenedTo { get => buttonListenedTo; set => buttonListenedTo = value; }
    public UnityEvent Response { get => response; set => response = value; }
}
