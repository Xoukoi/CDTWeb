<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Portafo1.WebForm1" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>Inicio de sesión</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
    <!-- Bootstrap 3.3.2 -->
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Font Awesome Icons -->
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="../../dist/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />
    <!-- iCheck -->
    <link href="../../plugins/iCheck/square/blue.css" rel="stylesheet" type="text/css" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
</head>
<body>

        <div>
            <div class="login-box">
      <div class="login-box-body">
        <h4>Ingrese sus datos</h4>
          <br />

        <form id="form2" runat="server">


                    <div class="col-md-6 text-center mb-5">
                    </div>
                    <br />
                              <br />
          <br />
                    <asp:Label ID="Label5" runat="server" Text="Usuario:"></asp:Label>
                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Rut"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Contraseña:"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                    <br />

                    <br />
                    <div class="row">
                        <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary btn-dark" Text="Ingresar" OnClick="Button1_Click" />
                    </div>
                    <br />
                    <br />
                    <div id="Div2" runat="server" visible="false" class="alert alert-danger">
                        <strong>Error!</strong>
                        <asp:Label ID="Label7" runat="server" />
                    </div>

            </form>

      </div><!-- /.login-box-body -->
    </div><!-- /.login-box -->


        </div>

</body>
</html>




