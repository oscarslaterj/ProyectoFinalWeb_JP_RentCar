<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="ProyectoFinalWeb_JPRentACar.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Iniciar Sesión</title>
    <meta name="viewport" content="width=device-width" />
    <meta charset="utf-8" />
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
    <link href="Content/Login/fonts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="Content/Login/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Login/vendor/animate/animate.css" rel="stylesheet" />
    <link href="Content/Login/vendor/animsition/css/animsition.min.css" rel="stylesheet" />
    <link href="Content/Login/vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" />
    <link href="Content/Login/vendor/select2/select2.min.css" rel="stylesheet" />
    <link href="Content/Login/vendor/daterangepicker/daterangepicker.css" rel="stylesheet" />
    <link href="Content/Login/css/main.css" rel="stylesheet" />
    <link href="Content/Login/css/util.css" rel="stylesheet" />
</head>

<body>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <form runat="server" class="login100-form validate-form p-l-55 p-r-55 p-t-178">
                    <span class="login100-form-title">Iniciar Sesion
                    </span>

                    <div class="wrap-input100 validate-input m-b-16" data-validate="Introducir Usuario">
                        <asp:TextBox CssClass="input100" AutoCompleteType="Disabled" placeholder="Usuario" ID="UsuarioTextBox" runat="server" />
                        <span class="focus-input100"></span>
                    </div>

                    <div class="wrap-input100 validate-input" data-validate="Introducir Contraseña">
                        <asp:TextBox CssClass="input100" AutoCompleteType="Disabled" placeholder="Contrasena" ID="PassTextBox" TextMode="Password" runat="server" />
                        <span class="focus-input100"></span>
                    </div>

                    <div class="text-right p-t-13 p-b-23">
                    </div>

                    <div class="container-login100-form-btn">
                        <asp:LinkButton Text="Entrar" ID="LoginLinkButton" OnClick="LoginLinkButton_Click" CssClass="login100-form-btn" runat="server" />

                    </div>

                    <div class="flex-col-c p-t-170 p-b-40">
                    </div>
                </form>
            </div>
        </div>
    </div>


    <script src="Content/Login/vendor/jquery/jquery-3.2.1.min.js"></script>
    <script src="Content/Login/vendor/animsition/js/animsition.min.js"></script>
    <script src="Content/Login/vendor/bootstrap/js/popper.js"></script>
    <script src="Content/Login/vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="Content/Login/vendor/select2/select2.min.js"></script>
    <script src="Content/Login/vendor/daterangepicker/moment.min.js"></script>
    <script src="Content/Login/vendor/daterangepicker/daterangepicker.js"></script>
    <script src="Content/Login/vendor/countdowntime/countdowntime.js"></script>
    <script src="Content/Login/js/main.js"></script>
</body>
</html>
