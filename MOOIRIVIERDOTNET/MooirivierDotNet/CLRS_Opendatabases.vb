Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports DAL

Module ModCLRS

    '* Purpose      : Set the databases
    'Dim dbPoldata5 As DAO.Database

    '* Purpose      : Update the CLRS field that determines if this policy will be updated to the CLRS system and how
    Public Function UpdateCLRSField(ByRef strTypeOfAmendment As String, ByRef strPolisno As String) As Object

        '	rs1.Edit()
        Select Case strTypeOfAmendment
            Case "A"
                'If this is an amendment to a new Client, then the Amendment type must stay 'N'
                If Persoonl.CLRSTypeOfAmendment = "N" Then
                    'Do nothing (Keep 'N')
                Else

                    Persoonl.CLRSTypeOfAmendment = strTypeOfAmendment

                End If

            Case Else
                Persoonl.CLRSTypeOfAmendment = strTypeOfAmendment
        End Select
        'Andriette 15/04/2014 skryf die clrs verandering na die tabel
        CLRSUpdateAmendmenttype(Persoonl.CLRSTypeOfAmendment)
        '      rs1.Update()


        Return Nothing
    End Function

    Sub CLRSUpdateAmendmenttype(strType As String)
        Try
            Dim params() As SqlParameter = {New SqlParameter("@POLISNO", SqlDbType.NVarChar), _
                      New SqlParameter("@CLRSTypeOfAmendment", SqlDbType.NVarChar), _
                      New SqlParameter("@Type", SqlDbType.NVarChar)}

            params(0).Value = glbPolicyNumber
            params(1).Value = strType
            params(2).Value = "UpdateCLRS"

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[poldata5].[UpdateCLRS]", params)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
End Module