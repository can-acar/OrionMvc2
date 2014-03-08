<%@ Page Language="C#" Inherits="OrionMvc.Web.View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> <%= ViewBag.Title %></title>
</head>
<body>
    <form id="form1">
        <div>
            <%= ViewBag.Content %>
            <%= ViewBag.deneme %>
            <%= ViewBag.Title %>
            <%= ViewBag.Body %>

            <%=ViewBag.LabelBody %>
        </div>
    </form>
</body>
</html>
