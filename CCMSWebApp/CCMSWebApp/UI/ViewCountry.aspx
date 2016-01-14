<%@ Page Title="View Country" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCountry.aspx.cs" Inherits="CCMSWebApp.ViewCountry" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <div class="panel panel-primary">
        <div class="panel-heading">View Country</div>
        <asp:Label runat="server" ID="messageLabel"></asp:Label>
        <div class="panel-body">
            <fieldset>
                <legend>Search</legend>
                <asp:Label runat="server" Text="Country Name"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="searchTextBox"></asp:TextBox>
                <br />
                <asp:Button ID="searchButton" runat="server" Text="Search" CssClass="btn btn-success" OnClick="searchButton_Click" />
                <br />
                <br />
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="showCuntryInformationGridView" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="showCuntryInformationGridView_PageIndexChanging" PageSize="2" EnableViewState="False">
                            <Columns>
                                <asp:TemplateField HeaderText="SL#">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("CountryName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="About">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("AboutCountry")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total City">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("NoOfCities")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Dwellers">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("NoOfCityDwellers")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:LinkButton runat="server" PostBackUrl="~/Default.aspx">Back</asp:LinkButton>
            </fieldset>
        </div>
    </div>
</asp:Content>
