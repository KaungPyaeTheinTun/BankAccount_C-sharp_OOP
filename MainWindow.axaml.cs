using System; 
using System.Collections.Generic; 
using Avalonia.Controls; 
using Avalonia.Interactivity; 
 
namespace MyApp; 
 
public partial class MainWindow : Window 
{ 
    List<BankAccount> BankAccounts = new List<BankAccount>(); 
 
    public MainWindow() 
    { 
        InitializeComponent(); 
    } 
 
    private async void CreateAccountBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(OwnerTextBox.Text))
        {
            await MessageDialog.Show(this, "Error", "Owner name cannot be empty!");
            return;
        }

        if(decimal.TryParse(InterestRateTextBox.Text, out decimal interestRate) && interestRate > 0)
        {   
            BankAccounts.Add(new SavingsAccount(OwnerTextBox.Text, interestRate));
        }
        else
        {
            BankAccounts.Add(new BankAccount(OwnerTextBox.Text));
        }

        RefreshGrid();
        OwnerTextBox.Text = string.Empty;
        InterestRateTextBox.Text = string.Empty;
    }
    private void RefreshGrid() 
    { 
        BankAccountsGrid.ItemsSource = null; 
        BankAccountsGrid.ItemsSource = BankAccounts; 
    } 
 
    private async void DepositBtn_Click(object? sender, RoutedEventArgs e)
    {
        if (BankAccountsGrid.SelectedItem is BankAccount selectedBankAccount)
        {
            if (!decimal.TryParse(AmountNum.Text, out decimal amount))
                return;

            string message = selectedBankAccount.Deposit(amount);
            RefreshGrid();
            AmountNum.Text = string.Empty;

            await MessageDialog.Show(this, "Deposit Result", message);
        }
    }
 
    private async void WithdrawBtn_Click(object? sender, RoutedEventArgs e)
    {
        if (BankAccountsGrid.SelectedItem is BankAccount selectedBankAccount)
        {
            if (!decimal.TryParse(AmountNum.Text, out decimal amount))
                return;

            string message = selectedBankAccount.Withdraw(amount);
            RefreshGrid();
            AmountNum.Text = string.Empty;

            await MessageDialog.Show(this, "Withdrawal Result", message);
        }
    }
 
}