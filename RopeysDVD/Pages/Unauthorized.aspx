<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Unauthorized.aspx.cs" Inherits="RopeysDVD.Unauthorized" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unauthorized Access</title>
    <link href="../css/Forbidden.css" rel="stylesheet" />
</head>
<body>
    <div class="scene">
        <div class="overlay"></div>
        <div class="overlay"></div>
        <div class="overlay"></div>
        <div class="overlay"></div>
        <span class="bg-403">403</span>
        <div class="text">
            <span class="hero-text"></span>
            <span class="msg">can't let <span>you</span> in.</span>
            <span class="support">
                <span>unexpected?</span>
                <a href="#" onclick="history.back()">Go Back</a>
            </span>
        </div>
        <div class="lock"></div>
    </div>
</body>
</html>
