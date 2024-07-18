﻿Imports System.Web.Http
Imports System.Web.Mvc
Imports System.Web.Optimization

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' É acionado quando o aplicativo é iniciado
        AreaRegistration.RegisterAllAreas()
        GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

    End Sub

    Public Sub Register(config As HttpConfiguration)
        ' Configuração de rotas da Web API
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
        name:="DefaultApi",
        routeTemplate:="api/{controller}/{id}",
        defaults:=New With {.id = RouteParameter.Optional}
    )
    End Sub
End Class