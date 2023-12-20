<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EncuestaForm.aspx.cs" Inherits="Examen3_Jurgen.EncuestaForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Llenar Encuesta</h2>
    <div>
        <asp:Label runat="server" ID="lblMensaje" ForeColor="Red"></asp:Label>
        <br />
        Nombre:
        <asp:TextBox runat="server" ID="txtNombre" />
        <br />
        Fecha de Nacimiento (YYYY-MM-DD):
        <asp:TextBox runat="server" ID="txtFechaNacimiento" />
        <br />
        Correo Electrónico:
        <asp:TextBox runat="server" ID="txtCorreoElectronico" />
        <br />
        Partido Político:
        <asp:DropDownList runat="server" ID="ddlPartidoPolitico">
            <asp:ListItem Value="1">PLN</asp:ListItem>
            <asp:ListItem Value="2">PUSC</asp:ListItem>
            <asp:ListItem Value="3">PAC</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button runat="server" ID="btnAgregar" Text="Agregar Encuesta" OnClick="btnAgregar_Click" />
    </div>
</asp:Content>
