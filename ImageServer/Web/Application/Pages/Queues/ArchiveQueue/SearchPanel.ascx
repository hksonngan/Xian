<%--  License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

--%>


<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SearchPanel.ascx.cs"
    Inherits="ClearCanvas.ImageServer.Web.Application.Pages.Queues.ArchiveQueue.SearchPanel" %>

<%@ Register Src="ArchiveQueueItemList.ascx" TagName="ArchiveQueueItemList" TagPrefix="localAsp" %>

<asp:UpdatePanel ID="SearchUpdatePanel" runat="server" UpdateMode="conditional">
    <ContentTemplate>

    <script>
    Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(InputHover);
    </script>

            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="right" VerticalAlign="Bottom" >
                    
                       <table cellpadding="0" cellspacing="0"  width="100%">
                            <!-- need this table so that the filter panel container is fit to the content -->
                            <tr>
                                <td align="left">
                                <asp:Panel ID="Panel6" runat="server" CssClass="SearchPanelContent" DefaultButton="SearchButton">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>

                                            <td align="left" valign="bottom">
                                                <asp:Label ID="Label1" runat="server" Text="<%$Resources: SearchFieldLabels, PatientName %>" CssClass="SearchTextBoxLabel"
                                                    EnableViewState="False" /><br />
                                                <asp:TextBox ID="PatientName" runat="server" CssClass="SearchTextBox" ToolTip="<%$Resources: Tooltips, SearchByPatientName %>" />
                                            </td>
                                            <td align="left" valign="bottom">
                                                <asp:Label ID="Label2" runat="server" Text="<%$Resources: SearchFieldLabels, PatientID %>" CssClass="SearchTextBoxLabel"
                                                    EnableViewState="False" /><br />
                                                <asp:TextBox ID="PatientId" runat="server" CssClass="SearchTextBox" ToolTip="<%$Resources: Tooltips, SearchByPatientID %>" />
                                            </td>
                                            <td align="left" valign="bottom">
                                                <asp:Label ID="Label5" runat="server" Text="<%$Resources: SearchFieldLabels, ArchiveQueueSchedule%>" CssClass="SearchTextBoxLabel" EnableViewState="false"/>
                                                <asp:LinkButton ID="ClearScheduleDateButton" runat="server" Text="X" CssClass="SmallLink"/><br />
                                                <ccUI:TextBox ID="ScheduleDate" runat="server" CssClass="SearchDateBox" ReadOnly="true" ToolTip="<%$Resources: Tooltips, SearchByScheduledDate %>" />
                                            </td>
                                            <td align="left" valign="bottom">
                                                <asp:Label ID="Label4" runat="server" Text="<%$Resources: SearchFieldLabels, ArchiveQueueStatus %>" CssClass="SearchTextBoxLabel"
                                                    EnableViewState="False" /><br />
                                                <asp:DropDownList ID="StatusFilter" runat="server" CssClass="SearchDropDownList" ToolTip="<%$Resources: Tooltips, SearchByStatus %>" />
                                            </td>                
                                            <td valign="bottom">
                                                <asp:Panel ID="Panel1" runat="server" CssClass="SearchButtonPanel"><ccUI:ToolbarButton ID="SearchButton" runat="server" SkinID="<%$Image:SearchIcon%>" OnClick="SearchButton_Click" /></asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                </td>
                            </tr>
                        </table>
                        <ccUI:CalendarExtender ID="ScheduleDateCalendarExtender" runat="server" TargetControlID="ScheduleDate"
                            CssClass="Calendar">
                        </ccUI:CalendarExtender>

                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <table width="100%" cellpadding="2" cellspacing="0" class="ToolbarButtonPanel">
                            <tr><td >
                            <asp:UpdatePanel ID="ToolBarUpdatePanel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="ToolbarButtons" runat="server" CssClass="ToolbarButtons">
										<ccUI:ToolbarButton ID="ViewStudyDetailsButton" runat="server" SkinID="<%$Image:ViewDetailsButton%>" />
                                        <ccUI:ToolbarButton ID="DeleteItemButton" runat="server" SkinID="<%$Image:DeleteButton%>" OnClick="DeleteItemButton_Click" />
                                        <ccUI:ToolbarButton ID="ResetItemButton" runat="server" SkinID="<%$Image:ResetButton%>" OnClick="ResetItemButton_Click" />
                                    </asp:Panel>
                             </ContentTemplate>
                          </asp:UpdatePanel>                  
                        </td></tr>
                        <tr><td>

                         <asp:Panel ID="Panel2" runat="server"  CssClass="SearchPanelResultContainer">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr><td><ccAsp:GridPager ID="GridPagerTop" runat="server" /></td></tr>                        
                                <tr><td style="background-color: white;"><localAsp:ArchiveQueueItemList id="ArchiveQueueItemList" runat="server" Height="500px"></localAsp:ArchiveQueueItemList></td></tr>
                            </table>                        
                        </asp:Panel>
                        </td>
                        </tr>
                        </table>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

    </ContentTemplate>
</asp:UpdatePanel>

        <ccAsp:MessageBox ID="MessageBox" runat="server" />    
