<%@ Page Title="Club View" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClubView.aspx.cs" Inherits="Tennisklubben_Ryvang.ClubView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 <div class="container py-5 h-100">>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" CellPadding="4" DataKeyNames="PhoneNumber,Email" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="Black" />
                <CommandRowStyle BackColor="Black" Font-Bold="True" />
                <EditRowStyle BackColor="Black" />
                <FieldHeaderStyle BackColor="Black" Font-Bold="True" />
                <Fields>
                    <asp:BoundField DataField="PersonID" HeaderText="PersonID" InsertVisible="False" ReadOnly="True" SortExpression="PersonID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" ReadOnly="True" SortExpression="PhoneNumber" />
                    <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" />
                    <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                    <asp:BoundField DataField="Registration_Date" HeaderText="Registration_Date" SortExpression="Registration_Date" />
                </Fields>
                <FooterStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="Black" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="Black" />
            </asp:DetailsView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Persons %>" SelectCommand="SELECT Persons.PersonID, Persons.Name, Persons.Address, Persons.PhoneNumber, Persons.Email, Persons_Payment.Age, Persons_Payment.Registration_Date FROM Persons INNER JOIN Persons_Payment ON Persons.Email = Persons_Payment.Email"></asp:SqlDataSource>
        </div>
</asp:Content>