namespace AppAg11;

public partial class MainPage : ContentPage
{
    public string vez = "X";
    public Button[,] board;
    public int rowBoard;
    public int colBoard;
    public int maxSquare;
    public string vitoria = "";
    public int jogada;

    public MainPage()
    {
        InitializeComponent();

        board = new Button[,]
        {
            { btn10, btn11, btn12 },
            { btn20, btn21, btn22 },
            { btn30, btn31, btn32 }
        };

        rowBoard = board.GetLength(0);
        colBoard = board.GetLength(1);
        maxSquare = rowBoard * colBoard;
    }

    private void Button_Clicked(Object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.IsEnabled = false;

        vez = Jogador(btn);

        Jogadas();

        Ganhador();

    }

    private string Jogador(Button btn)
    {
        if (vez == "X")
        {
            btn.Text = "X";
            return vez = "O";
        }
        else
        {
            btn.Text = "O";
            return vez = "X";
        }

    }

    private int? Jogadas()
    {        
        return jogada++;
    }

    private string VerificaVitoria()
    {
        
        string vitoria = VerificaLinha();
        if (!String.IsNullOrEmpty(vitoria))
        {
            return vitoria;
        }

        
        vitoria = VerificaColuna();
        if (!String.IsNullOrEmpty(vitoria))
        {
            return vitoria;
        }

        
        vitoria = VerificaDiagonais();
        if (!String.IsNullOrEmpty(vitoria))
        {
            return vitoria;
        }

        
        return VerificaEmpate();
    }


    private string VerificaEmpate()
    {
        for (int row = 0; row < rowBoard; row++)
        {
            for (int col = 0; col < colBoard; col++)
            {
                if (board[row, col] == null)
                {
                    return "";
                }
            }
        }

        if (maxSquare == jogada)
        {
            return "V";
        }
        else
        {
            return "";
        }
    }


    public string VerificaLinha()
    {
        for (int row = 0; row < rowBoard; row++)
        {
            int contX = 0;
            int contO = 0;

            for (int col = 0; col < colBoard; col++)
            {
                if (board[row, col].Text == "X")
                {
                    contX++;
                }
                else if (board[row, col].Text == "O")
                {
                    contO++;
                }
            }

            if (contX == colBoard)
            {
                return "X";
            }
            else if (contO == colBoard)
            {
                return "O";
            }
        }

        return "";
    }


    private string VerificaColuna()
    {
        for (int col = 0; col < colBoard; col++)
        {
            int contX = 0;
            int contO = 0;

            for (int row = 0; row < rowBoard; row++)
            {
                if (board[row, col].Text == "X")
                {
                    contX++;
                }
                else if (board[row, col].Text == "O")
                {
                    contO++;
                }
            }

            if (contX == rowBoard)
            {
                return "X";
            }
            else if (contO == rowBoard)
            {
                return "O";
            }
        }

        return "";
    }


    private string VerificaDiagonais()
    {
        int contX = 0;
        int contO = 0;

        for (int i = 0; i < rowBoard; i++)
        {
            if (board[i, i].Text == "X")
            {
                contX++;
            }
            else if (board[i, i].Text == "O")
            {
                contO++;
            }
        }

        if (contX == rowBoard)
        {
            return "X";
        }
        else if (contO == rowBoard)
        {
            return "O";
        }

        contX = 0;
        contO = 0;

        for (int i = 0; i < rowBoard; i++)
        {
            if (board[i, rowBoard - i - 1].Text == "X")
            {
                contX++;
            }
            else if (board[i, rowBoard - i - 1].Text == "O")
            {
                contO++;
            }
        }

        if (contX == rowBoard)
        {
            return "X";
        }
        else if (contO == rowBoard)
        {
            return "O";
        }

        return "";
    }


    private void Zerar()
    {

        foreach (Button square in board)
        {
            square.Text = "";
            square.IsEnabled = true;
        }

        vitoria = "início";
    }


    private void Ganhador()
    {
        String? ganhador = VerificaVitoria();
        switch (ganhador)
        {
            case "X":
                DisplayAlert("Parabéns!", $"O jogador {ganhador} ganhou!", "OK");
                Zerar();
                break;
            case "O":
                DisplayAlert("Parabéns!", $"O jogador {ganhador} ganhou!", "OK");
                Zerar();
                break;
            case "V":
                DisplayAlert("Parabéns!", $"O jogador {ganhador} ganhou!", "OK");
                Zerar();
                break;
        }

    }


}