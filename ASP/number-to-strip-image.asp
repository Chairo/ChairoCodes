如何将数字转化成条形图？
见下，把数字转成条形图的一个程序：
<%
Sub ShowChart(ByRef aValues, ByRef aLabels, ByRef strTitle, ByRef strXAxisLabel, ByRef strYAxisLabel)
      ' 定义图形常量
      Const GRAPH_WIDTH  = 450 
' 以屏幕分辨率为单位, GRAPH_WIDTH为图形宽度
      Const GRAPH_HEIGHT = 250 
 ' 图形高度
      Const GRAPH_BORDER = 5   
 ' 黑边宽度      
Const GRAPH_SPACER = 2    
' 图形两栏之间的空间

      Const TABLE_BORDER = 0
      'Const TABLE_BORDER = 10

      Dim I
      Dim iMaxValue
      Dim iBarWidth
      Dim iBarHeight
      ' 声明变量

      iMaxValue = 0
      For I = 0 To UBound(aValues)
            If iMaxValue < aValues(I) Then iMaxValue = aValues(I)     
  ' 得到数据组的最大值

      Next 'I
      ' Response.Write iMaxValue 


       iBarWidth = (GRAPH_WIDTH \ (UBound(aValues) + 1)) - GRAPH_SPACER
' 计算栏的宽度,把全宽用每一段的数目表示,不足一段向下舍入
      'Response.Write iBarWidth 

      ' 下面开始画图形
      %>
      <TABLE BORDER="<%= TABLE_BORDER %>" CELLSPACING="0" CELLPADDING="0">
            <TR>
            <TD COLSPAN="3" ALIGN="center"><H2><%= strTitle %></H2></TD>
            </TR>
            <TR>
                  <TD VALIGN="center"><B><%= strYAxisLabel %></B></TD>
                  <TD VALIGN="top">
                <TABLE BORDER="<%= TABLE_BORDER %>" CELLSPACING="0" CELLPADDING="0">
                   <TR>
               <TD ROWSPAN="2"><IMG SRC="./images/spacer.gif" BORDER="0" WIDTH="1" 
HEIGHT="<%= GRAPH_HEIGHT %>"></TD>
                   <TD VALIGN="top" ALIGN="right"><%= iMaxValue %>&nbsp;</TD>
                   </TR>
                   <TR>
                   <TD VALIGN="bottom" ALIGN="right">0&nbsp;</TD>
                   </TR>
                   </TABLE>
                   </TD>
                   <TD>
                   <TABLE BORDER="<%= TABLE_BORDER %>" CELLSPACING="0" CELLPADDING="0">
                   <TR>
                 <TD VALIGN="bottom">
<IMG SRC="./images/spacer_black.gif" BORDER="0" WIDTH="<%= GRAPH_BORDER %>" HEIGHT="<%= GRAPH_HEIGHT %>"></TD>
                   <% 
   For I = 0 To UBound(aValues)
                 iBarHeight = Int((aValues(I) / iMaxValue) * GRAPH_HEIGHT)

                   If iBarHeight = 0 Then iBarHeight = 1
                   %>
                 <TD VALIGN="bottom"><IMG SRC="./images/spacer.gif" BORDER="0" WIDTH="<%= GRAPH_SPACER %>" HEIGHT="1"></TD>
              <TD VALIGN="bottom"><IMG SRC="./images/spacer_red.gif" BORDER="0" WIDTH="<%= iBarWidth %>" HEIGHT="<%= iBarHeight %>" ALT="<%= aValues(I) %>"></A></TD>
                 <%
                 Next 'I
                 %>
                 </TR>
                 <TR>
              <TD COLSPAN="<%= (2 * (UBound(aValues) + 1)) + 1 %>"><IMG SRC="./images/spacer_black.gif" BORDER="0" WIDTH="<%= GRAPH_BORDER + ((UBound(aValues) + 1) * (iBarWidth + GRAPH_SPACER)) %>" HEIGHT="<%= GRAPH_BORDER %>"></TD>
                 </TR>
                 <% If IsArray(aLabels) Then %>
                 <TR>
                 <TD>栏左边框间距</TD>
                 <% For I = 0 To UBound(aValues)  %>
                 <TD 
ALIGN="center"><FONT SIZE="1"><%= aLabels(I) %></FONT></TD>
                 <% Next 'I %>;
                 </TR>
                 <% End If %>
 </TABLE>
  </TD>
</TR>
               <TR>
                 <TD COLSPAN="2">
                 <TD ALIGN="center"><BR><B><%= strXAxisLabel %></B></TD>
' 设置坐标中心
               </TR>
    </TABLE>
<%
End Sub
%>
<%
' Static Chart (with Bar Labels)
ShowChart Array(6, 10, 12, 18, 23, 26, 27, 28, 30, 34, 37, 45, 55), Array("P1", "P2", "P3", "P4", "P5", "P6", "P7", "P8", "P9", "P10", "P11", "P12", "P13"), "Chart Title", "X Label", "Y Label"

Response.Write "<BR>" & vbCrLf
Response.Write "<BR>" & vbCrLf
Response.Write "<BR>" & vbCrLf
' 间距

Dim I
Dim aTemp(49)
' 随机数表示

Randomize
For I = 0 to 49
      aTemp(I) = Int((50 + 1) * Rnd)
Next 'I

' 利用随机数生成统计图
ShowChart aTemp, , "Chart of 50 Random Numbers", "Index", "Value"
%>
