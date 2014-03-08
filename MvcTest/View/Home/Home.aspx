<%@ Page Language="C#" Inherits="OrionMvc.Web.View" %>

<p>Home içerik Test</p>
<p>
    <%   var html = string.Empty;

         foreach (DictionaryEntry listOfparams in ViewBag)
         {
             if (listOfparams.Value is ViewData)
             {
               
             }
             html += "Params" + listOfparams.Key + "----" + "value" + listOfparams.Value;
         }
      
    %>
    <%=html %>
</p>

