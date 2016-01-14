<%@ Page Title="View City" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCity.aspx.cs" Inherits="CCMSWebApp.ViewCity" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <div class="panel panel-primary">
        <div class="panel-heading">City Inforamtion</div>
        <asp:Label runat="server" ID="messageLabel"></asp:Label>
        <div id="searchSection" style="margin-left: 50px; height: 164px; width: 345px;">
            <fieldset style="width: 271px;">
                <legend>Search Criteria </legend>
                <div style="float: left">
                    <asp:RadioButtonList ID="serarchKeyRadioButton" runat="server">
                        <asp:ListItem Value="1"> City Name</asp:ListItem>
                        <asp:ListItem Value="2"> Country</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div>
                    <asp:TextBox ID="cityNameTextBox" CssClass="pull-right" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:DropDownList ID="countryDropDownList" CssClass="form-control" runat="server" Width="172px"></asp:DropDownList>
                </div>
                <div style="float: right">
                    <br />
                    <asp:Button ID="searchButton" runat="server" CssClass="btn btn-success" Text="Search" OnClick="searchButton_Click" />
                </div>
            </fieldset>
        </div>
        <div class="panel-body">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:GridView ID="showCityInformationGridView" CssClass="table table-bordered table-hover" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="2" OnPageIndexChanging="showCityInformationGridView_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="SL#">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City Name">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("CityName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="About">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("AboutCity") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No. of Dwellers">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("NoOfDewellers") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("Location") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Weather">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("Weather") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("CountryName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="About Country">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("AboutCountry") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:LinkButton runat="server" PostBackUrl="~/Default.aspx">Back</asp:LinkButton>
        </div>
    </div>
</asp:Content>
