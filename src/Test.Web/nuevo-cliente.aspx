<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nuevo-cliente.aspx.cs" Inherits="Test.Web.Nuevo_cliente" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="section contact" id="contact">
        <h1 class="section-title section-contact-title">Nuevo Registro
        </h1>
        <span class="section-subtitle section-contact-subtitle">Completa el siguiente formulario para agregar un nuevo cliente
        </span>
        <div class="contact-container container grid">
            <div id="contact-form" class="contact-form grid" autocomplete="on">
                <asp:Image ImageUrl="/Content/male_avatar.svg" runat="server" CssClass="services-icon" />
                <h2 class="services-title" id="customerName"></h2>
                <div class="contact-inputs grid">
                    <div class="contacts-inputs-inline">
                        <div>
                            <label for="TxtFirstName" class="contact-label required">Primer Nombre</label>
                            <div class="contact-content">
                                <i class="uil uil-user icon-input"></i>
                                <asp:TextBox runat="server" ClientIDMode="Static" type="text" name="TxtFirstName" ID="TxtFirstName" CssClass="contact-input" autocomplete="on" required="" placeholder="1er nombre" />
                            </div>
                        </div>
                        <div>
                            <label for="TxtSecondName" class="contact-label">Segundo Nombre</label>
                            <div class="contact-content">
                                <i class="uil uil-user icon-input"></i>
                                <asp:TextBox runat="server" ClientIDMode="Static" type="text" name="TxtSecondName" ID="TxtSecondName" CssClass="contact-input" autocomplete="on" placeholder="2do nombre" />
                            </div>
                        </div>
                    </div>
                    <div class="contacts-inputs-inline">
                        <div>
                            <label for="TxtFirstLastName" class="contact-label required">Primer Apellido</label>
                            <div class="contact-content">
                                <i class="uil uil-user icon-input"></i>
                                <asp:TextBox runat="server" ClientIDMode="Static" type="text" name="TxtFirstLastName" ID="TxtFirstLastName" CssClass="contact-input" autocomplete="on" required="" placeholder="1er Apellido" />
                            </div>
                        </div>
                        <div>
                            <label for="TxtSecondLastName" class="contact-label">Segundo Nombre</label>
                            <div class="contact-content">
                                <i class="uil uil-user icon-input"></i>
                                <asp:TextBox runat="server" ClientIDMode="Static" type="text" name="TxtSecondLastName" ID="TxtSecondLastName" CssClass="contact-input" autocomplete="on" placeholder="2do apellido" />
                            </div>
                        </div>
                    </div>

                </div>

                <div>
                    <label for="DropListIdType" class="contact-label required">Tipo de identificación</label>
                    <div class="contact-content">
                        <i class="uil uil-transaction icon-input"></i>
                        <asp:DropDownList runat="server" ClientIDMode="Static" ID="DropListIdType" class="contact-input select">
                        </asp:DropDownList>
                    </div>
                </div>

                <div>
                    <label for="TxtIdNumber" class="contact-label required">No de identificación</label>
                    <div class="contact-content">
                        <i class="uil uil-estate icon-input"></i>
                        <asp:TextBox runat="server" ClientIDMode="Static" type="text" name="TxtIdNumber" ID="TxtIdNumber" CssClass="contact-input" autocomplete="on" required="" placeholder="No de identificación" />
                    </div>
                </div>

                <div class="contacts-inputs-inline">
                    <div>
                        <label for="TxtCountry" class="contact-label required">País</label>
                        <div class="contact-content">
                            <i class="uil uil-estate icon-input"></i>
                            <asp:TextBox runat="server" ClientIDMode="Static" type="text" name="TxtCountry" ID="TxtCountry" CssClass="contact-input" autocomplete="on" required="" placeholder="Nicaragua" />
                        </div>
                    </div>
                    <div>
                        <label for="TxtState" class="contact-label required">Departamento</label>
                        <div class="contact-content">
                            <i class="uil uil-estate icon-input"></i>
                            <asp:TextBox runat="server" ClientIDMode="Static" type="text" name="TxtState" ID="TxtState" CssClass="contact-input" autocomplete="on" required="" placeholder="Chinandega" />
                        </div>
                    </div>
                </div>


                <div class="contacts-inputs-inline">
                    <div>
                        <label for="TxtCity" class="contact-label required">Ciudad</label>
                        <div class="contact-content">
                            <i class="uil uil-estate icon-input"></i>
                            <asp:TextBox runat="server" ClientIDMode="Static" type="text" name="TxtCity" ID="TxtCity" CssClass="contact-input" required="" placeholder="El viejo" />
                        </div>
                    </div>
                    <div>
                        <label for="TxtNeighborhood" class="contact-label required">Barrio</label>
                        <div class="contact-content">
                            <i class="uil uil-estate icon-input"></i>
                            <asp:TextBox runat="server" ClientIDMode="Static" type="text" name="TxtNeighborhood" ID="TxtNeighborhood" CssClass="contact-input" required="" autocomplete="on" placeholder="Residencial La fé" />
                        </div>
                    </div>
                </div>
                <div>
                    <label for="TxtAddress" class="contact-label required">Dirección</label>
                    <div class="contact-content">
                        <i class="uil uil-user-location icon-input"></i>
                        <asp:TextBox runat="server" ClientIDMode="Static" type="text" name="TxtAddress" ID="TxtAddress" CssClass="contact-input" required="" autocomplete="on" placeholder="Dirección" />
                    </div>
                </div>

                <div>
                    <button class="button contact-button button--flex" onserverclick="BtnRegisterCustomer_Click" runat="server" onclick="if (!validForm()) return false;">
                        <i class="uil uil-file-plus-alt"></i>
                        Registrar cliente
                    </button>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
