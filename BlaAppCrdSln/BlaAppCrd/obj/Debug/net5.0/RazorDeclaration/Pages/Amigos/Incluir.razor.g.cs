// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlaAppCrd.Pages.Amigos
{
    #line hidden
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 3 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\_Imports.razor"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\_Imports.razor"
using System.Security.Principal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\_Imports.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\_Imports.razor"
using Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\Pages\Amigos\Incluir.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\Pages\Amigos\Incluir.razor"
using System.Net.Http.Headers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\Pages\Amigos\Incluir.razor"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\Pages\Amigos\Incluir.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\Pages\Amigos\Incluir.razor"
using System.Text.Json.Serialization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\Pages\Amigos\Incluir.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\Pages\Amigos\Incluir.razor"
using CommonCrd.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\Pages\Amigos\Incluir.razor"
using CommonCrd.DataServices;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\Pages\Amigos\Incluir.razor"
using static CommonCrd.Code.GLB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\Pages\Amigos\Incluir.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\Pages\Amigos\Incluir.razor"
using Syncfusion.Blazor.Cards;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\Pages\Amigos\Incluir.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Incluir")]
    public partial class Incluir : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 104 "D:\Tutorials\BlazorCrud\BlaAppCrdSln\BlaAppCrd\Pages\Amigos\Incluir.razor"
       
    private AmigosMd Amg = new AmigosMd();
    private string Msg = string.Empty;

    private void SaveAmigo()
    {
        try
        {
            AmigosDal Am = new AmigosDal();
            CodeMsg cm = Am.Incluir(Amg);
            if (cm.ErrCode == 0)
            { Msg = ""; Amg = new AmigosMd(); }     //  Gravou, limpa a tela
            else
            { Msg = cm.ErrMsg; }                    //  Erro monitorado pelo programa
        }
        catch (Exception ex)
        {
            Msg = "Erro de gravação : " + ex.Message;   //  Erro nao esperado. queda de internet, etc
        }
    }

    private async void SaveAmigoApi()
    {
        try
        {
            // Send the POST Request to the Authentication Server
            string json = await Task.Run(() => JsonConvert.SerializeObject(Amg));
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (var h = new HttpClient())
            {
                //  Define o modo de recebimento dos dados (JSON) . Poderia ser XML por ex;
                h.DefaultRequestHeaders.Accept.Clear();
                h.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //  Informa o endereço base (parte fixa) da API
                h.BaseAddress = new Uri(BaseAddress);
                // Error here
                var httpResponse = await h.PostAsync( h.BaseAddress, httpContent);
                if (httpResponse.Content != null)
                {
                    // Error Here
                    Msg = await httpResponse.Content.ReadAsStringAsync();
                    this.StateHasChanged();
                }
            }
        } catch (Exception ex) { throw ex; }
    }

    private void Cancel()
    {
        //  Clear screeen
        Msg = ""; Amg = new AmigosMd();
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
