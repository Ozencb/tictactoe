<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TicTacToe.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="index.css" rel="stylesheet" />
</head>
<body>
    <form id="form" runat="server" >
        <div class="container" >
            <div class="score-board" >
                <asp:Label ID="player1" CssClass="player player-1" runat="server" >Player 1
                    <asp:Label ID="symbol1" CssClass="symbol" runat="server" ></asp:Label>
                </asp:Label>
                <asp:Label ID="score" CssClass="score" runat="server">0 - 0</asp:Label>
                <asp:Label ID="player2" CssClass="player player-2" runat="server" >Player 2
                    <asp:Label ID="symbol2" CssClass="symbol" runat="server" ></asp:Label>
                </asp:Label>
            </div>
            <hr />
            <asp:Label ID="gameMessage" CssClass="game-message" runat="server" ></asp:Label>
            <div class="game-board" id="board" runat="server" >
                <asp:Button ID="btn0" Text="" CssClass="btn btn-cell" runat="server" OnClick="markCell" />
                <asp:Button ID="btn1" Text="" CssClass="btn btn-cell" runat="server" OnClick="markCell" />
                <asp:Button ID="btn2" Text="" CssClass="btn btn-cell" runat="server" OnClick="markCell" />
                <asp:Button ID="btn3" Text="" CssClass="btn btn-cell" runat="server" OnClick="markCell" />
                <asp:Button ID="btn4" Text="" CssClass="btn btn-cell" runat="server" OnClick="markCell" />
                <asp:Button ID="btn5" Text="" CssClass="btn btn-cell" runat="server" OnClick="markCell" />
                <asp:Button ID="btn6" Text="" CssClass="btn btn-cell" runat="server" OnClick="markCell" />
                <asp:Button ID="btn7" Text="" CssClass="btn btn-cell" runat="server" OnClick="markCell" />
                <asp:Button ID="btn8" Text="" CssClass="btn btn-cell" runat="server" OnClick="markCell" />
            </div>
            <asp:Button ID="btnRestart" Text="Play Again" CssClass="btn btn-restart" runat="server" OnClick="restartGame" />
        </div>
    </form>

</body>
</html>
