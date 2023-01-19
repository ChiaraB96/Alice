public class DialogueEventSystem
{
    public delegate void DialogEvent();
    public static event DialogEvent OnDialogShown;
    public static event DialogEvent OnDialogHidden;

    public static void ShowDialog()
    {
        // Mostrar el cuadro de diálogo y el texto
        dialogueBox.SetActive(true);
        if(OnDialogShown != null)
            OnDialogShown();
    }

    public static void HideDialog()
    {
        // Ocultar el cuadro de diálogo y el texto
        dialogueBox.SetActive(false);
        if(OnDialogHidden != null)
            OnDialogHidden();
    }
}