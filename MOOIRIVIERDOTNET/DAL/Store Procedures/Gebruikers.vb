Imports System.Text

Public Class Gebruikers

    Public Shared Function FetchString(ByVal username As String) As String
        Dim sb As StringBuilder = New StringBuilder()
        sb.Append("select * FROM Gebruikers ")
        'sb.Append("SELECT Naam,Nedseedno,Kode,")
        'sb.Append("titel,BranchCodes,Policynumber")
        'sb.Append("WindowsUsername,ApplicationPath,Area_kode")
        'sb.Append(" FROM Gebruikers ")
        sb.Append("WHERE Naam = '")
        sb.Append(username)
        sb.Append("'")
        Return sb.ToString()
    End Function
End Class
