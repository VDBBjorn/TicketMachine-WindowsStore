namespace TicketMachine.Lib.Services
{
    public interface IDialogService
    {
        void ShowDialog(string message);
        void ShowDeleteConfirmation();
    }
}