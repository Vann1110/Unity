namespace TicTacToe
{
    public class GameData
    {
        private static GameData instance = null;
        public static GameData Inst
        {
            get
            {
                if (GameData.instance == null)
                {
                    GameData.instance = new GameData();
                }
                return GameData.instance;
            }
        }

        private UIManager ui = null;

        public void registerUI(UIManager ui)
        {
            this.ui = ui;
        }

        public void init()
        {
            this._gameSet = 0;
        }

        private GameState _gameState = GameState.Idle;
        public GameState gameState { get { return this._gameState; } }   //遊戲狀態
        public void gameStart()
        {
            this._gameState = GameState.Loop;
            this.newGame();
        }

        private int _gameSet = 0;   //局數
        public int gameSet { get { return this._gameSet; } }
        // 新遊戲
        public void newGame()
        {
            this._gameSet++;
            this.ui.topPanel.updateInfo();
        }

        private int _blackWins = 0;  //黑贏局數
        public int blackWins { get { return this._blackWins; } }
        public void setBlackWin()
        {
            this._blackWins++;
            this._gameState = GameState.Over;
            this.ui.topPanel.updateInfo();
            this.ui.controlPanel.showRestart("黑贏!");
        }
        private int _whiteWins = 0;  //白贏局數
        public int whiteWins { get { return this._whiteWins; } }
        public void setWhiteWin()
        {
            this._whiteWins++;
            this._gameState = GameState.Over;
            this.ui.topPanel.updateInfo();
            this.ui.controlPanel.showRestart("白贏!");
        }

        public void setDraw()
        {
            this._gameState = GameState.Over;
            this.ui.controlPanel.showRestart("平手!");
        }
    }

    public enum GameState
    {
        Idle,
        Start,
        Loop,
        Pause,
        Over,
    }
}
