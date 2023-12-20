<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteEncuestas.aspx.cs" Inherits="Examen3_Jurgen.ReporteEncuestas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Reporte de Encuestas</h2>
    <asp:Label runat="server" ID="lblMensaje" ForeColor="Red"></asp:Label>
    <asp:GridView ID="gvReporte" runat="server"></asp:GridView>
</asp:Content>