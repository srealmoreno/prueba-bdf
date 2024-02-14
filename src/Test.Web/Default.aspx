<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Test.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="section skills" id="skills">
        <h1 class="section-title section-skills-title">Inicio
        </h1>
        <span class="section-subtitle section-skills-subtitle">Clientes registrados en el sistema
        </span>

        <div class="skills-container container grid">
            <asp:ListView ID="viewClient" runat="server">
                <ItemTemplate>
                    <div class="services-content">
                        <asp:Image ImageUrl="/Content/male_avatar.svg" runat="server" CssClass="services-icon" />
                        <h2 class="services-title">
                            <%# Eval("firstName") %> <%# Eval("firstLastName") %>
                        </h2>
                        <div class="services-element">
                            <i class="uil uil-file-blank skill-icon"></i>
                            <p>
                                <%# Eval("idType") %>
                            </p>
                        </div>

                        <div class="services-element">
                            <i class="uil uil-user-square skill-icon"></i>
                            <p>
                                <%# Eval("idNumber") %>
                            </p>
                        </div>

                        <asp:ListView ID="viewAddress" runat="server" DataSource='<%# Eval("address") %>'>
                            <ItemTemplate>
                                <div class="services-element">
                                    <i class="uil uil-user-location skill-icon"></i>
                                    <p>
                                        <%# Eval("City") %>, <%# Eval("State") %>
                                    </p>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>

                        <div class="services-element">
                            <i class="uil uil-bill skill-icon"></i>
                            <p>C$ 1,000</p>
                        </div>



                        <div class="services-button">
                            <asp:LinkButton runat="server" CssClass="button button-service" OnClick="BtnEdit_Click" CommandArgument='<%# Eval("customerId") %>'>
                                          <i class="uil uil-pen"></i>
                                            Editar
                            </asp:LinkButton>

                            <asp:LinkButton runat="server" CssClass="button button-delete button-service" OnClick="BtnDelete_Click" CommandArgument='<%# Eval("customerId") %>' OnClientClick="return window.confirm('¿Estas seguro de eliminar este cliente?');">
                                        <i class="uil uil-trash"></i>
                                        Eliminar
                            </asp:LinkButton>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </section>
    <asp:Panel ID="tableEmpty" runat="server" Visible="false">
        <section class="section error" id="error">
            <div class="error-container container">
                <div class="error-data">
                    <img async="" loading="lazy" class="error-img" src="/Content/Empty.svg" alt="error" width="280" height="280" srcset="">
                    <p class="error-description">¡Oops! No hay clientes registrados en el sistema</p>
                    <a href="nuevo-cliente.aspx" class="button">
                        <i class="uil uil-plus"></i>
                        Agregar cliente
                    </a>
                </div>
            </div>
        </section>
    </asp:Panel>
</asp:Content>
