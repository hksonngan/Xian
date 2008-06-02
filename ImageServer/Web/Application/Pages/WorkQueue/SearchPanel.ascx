<%@ Import Namespace="ClearCanvas.ImageServer.Web.Common.WebControls.UI" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SearchPanel.ascx.cs"
    Inherits="ClearCanvas.ImageServer.Web.Application.Pages.WorkQueue.SearchPanel" %>
<%@ Register Src="WorkQueueItemListPanel.ascx" TagName="WorkQueueSearchResultPanel" TagPrefix="localAsp" %>
    
<asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
    <ContentTemplate>

<div>
        <b class="roundedCorners"><b class="roundedCorners1"><b></b></b><b class="roundedCorners2">
            <b></b></b><b class="roundedCorners3"></b><b class="roundedCorners4"></b><b class="roundedCorners5">
            </b></b>
        <div class="roundedCornersfg">
        
            <asp:Table ID="Table" runat="server" Width="100%" CellPadding="0" BorderWidth="0px">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="right">                          
                                <asp:Panel ID="Panel6" runat="server" CssClass="SearchPanelContent" DefaultButton="SearchButton">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="left" valign="bottom">
                                                <asp:Label ID="Label2" runat="server" Text="Patient ID" CssClass="SearchTextBoxLabel"
                                                    EnableViewState="False" /><br />
                                                <asp:TextBox ID="PatientId" runat="server" CssClass="SearchTextBox" ToolTip="Search the list by Patient Id" />
                                            </td>
                                            <td align="left" valign="bottom">
                                                <asp:Label ID="Label3" runat="server" Text="Accession#" CssClass="SearchTextBoxLabel"
                                                    EnableViewState="False" /><br />
                                                <asp:TextBox ID="AccessionNumber" runat="server" CssClass="SearchTextBox" ToolTip="Search the list by Accession Number" />
                                            </td>
                                            <td align="left" valign="bottom">
                                                <asp:Label ID="Label4" runat="server" Text="Description" CssClass="SearchTextBoxLabel"
                                                    EnableViewState="False" /><br />
                                                <asp:TextBox ID="StudyDescription" runat="server" CssClass="SearchTextBox" ToolTip="Search the list by Study Description" />
                                            </td>
                                            <td align="left" valign="bottom">
                                                <asp:Label ID="Label1" runat="server" Text="Schedule" CssClass="SearchTextBoxLabel" />
                                                <asp:ImageButton ID="ClearScheduleDateButton" runat="server" ImageUrl="~/images/icons/ClearDate.png" AlternateText="Clear Date" /><br />
                                                <asp:TextBox ID="ScheduleDate" runat="server" ReadOnly="true" CssClass="SearchTextBox" BackColor="White" ToolTip="Search the list by Schedule Date [dd/mm/yyyy]" />
                                            </td>
                                            <td align="left" valign="bottom">
                                                <asp:Label ID="Label5" runat="server" Text="Type" CssClass="SearchTextBoxLabel"
                                                    EnableViewState="False" /><br />
                                                <asp:DropDownList ID="TypeDropDownList" runat="server" CssClass="SearchDropDownList" Width="120px">
                                                </asp:DropDownList></td>
                                            <td align="left" valign="bottom">
                                                <asp:Label ID="Label6" runat="server" Text="Status" CssClass="SearchTextBoxLabel"
                                                    EnableViewState="False" /><br />
                                                <asp:DropDownList ID="StatusDropDownList" runat="server" CssClass="SearchDropDownList">
                                                </asp:DropDownList></td>
                                            <td align="left" valign="bottom">
                                                <asp:Label ID="Label7" runat="server" Text="Priority" CssClass="SearchTextBoxLabel"
                                                    EnableViewState="False" /><br />
                                                <asp:DropDownList ID="PriorityDropDownList" runat="server" CssClass="SearchDropDownList">
                                                </asp:DropDownList></td>
                                            <td align="right" valign="bottom">
                                                <asp:Panel ID="Panel1" runat="server" CssClass="SearchButtonPanel"><asp:ImageButton ID="SearchButton" runat="server" ImageUrl="~/images/icons/QueryEnabled.png"
                                                    OnClick="SearchButton_Click" ToolTip="Search" /></asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                        <aspAjax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="ScheduleDate"
                            CssClass="Calendar">
                        </aspAjax:CalendarExtender>
                    </asp:TableCell> 
                </asp:TableRow>
                     <asp:TableRow>
                        <asp:TableCell>
                        <table width="100%" cellpadding="2" cellspacing="0" class="ToolbarButtonPanel">
                            <tr><td >
                            <asp:UpdatePanel ID="ToolBarUpdatePanel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="ToolbarButtons" runat="server" CssClass="ToolbarButtons">
                                        <ccUI:ToolbarButton ID="ViewItemDetailsButton" runat="server" SkinID="ViewDetailsButton" />
                                        <ccUI:ToolbarButton ID="RescheduleItemButton" runat="server" SkinID="RescheduleButton" />
                                        <ccUI:ToolbarButton ID="ResetItemButton" runat="server" SkinID="ResetButton" />
                                        <ccUI:ToolbarButton ID="DeleteItemButton" runat="server" SkinID="DeleteButton" />
                                    </asp:Panel>
                             </ContentTemplate>
                          </asp:UpdatePanel>                  
                        </td></tr>
                        <tr><td>

                         <asp:Panel ID="Panel2" runat="server" style="border: solid 1px #3d98d1; ">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                 <tr><td style="border-bottom: solid 1px #3d98d1"><ccAsp:GridPager ID="GridPagerTop" runat="server" /></td></tr>                        
                                <tr><td style="background-color: white;"><localAsp:WorkQueueSearchResultPanel ID="workQueueItemListPanel" Height="500px" AllowPaging="true" PageSize="20" runat="server"></localAsp:WorkQueueSearchResultPanel></td></tr>
                                <tr><td style="border-top: solid 1px #3d98d1"><ccAsp:GridPager ID="GridPagerBottom" runat="server" /></td></tr>                    
                            </table>
                         
                        </asp:Panel>
                        </td>
                        </tr>
                        </table>
                    </asp:TableCell>
                </asp:TableRow>

            </asp:Table>


    </div>
        <b class="roundedCorners"><b class="roundedCorners5"></b><b class="roundedCorners4">
        </b><b class="roundedCorners3"></b><b class="roundedCorners2"><b></b></b><b class="roundedCorners1">
            <b></b></b></b>
    </div>

    </ContentTemplate>
</asp:UpdatePanel>

<ccAsp:ConfirmationDialog runat="server" ID="ConfirmationDialog" />
