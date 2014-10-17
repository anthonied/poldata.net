'Linkie 28/03/2012
'Entity for comboboxes - for the entire application
Imports System.ComponentModel
Public Class ComboBoxEntity
    Private m_ComboBoxName As String
    Private m_ComboBoxID As Integer
    Private m_ComboboxPosition As Integer

    <DataObjectField(False, False, False)> _
    Public Property ComboBoxName() As String
        Get
            Return m_ComboBoxName
        End Get
        Set(ByVal value As String)
            m_ComboBoxName = value
        End Set
    End Property
    <DataObjectField(False, False, False)> _
    Public Property ComboBoxID() As Integer
        Get
            Return m_ComboBoxID
        End Get
        Set(ByVal value As Integer)
            m_ComboBoxID = value
        End Set
    End Property
    ' Andriette 18/04/2013 Voeg die combo posisie ook by
    <DataObjectField(False, False, False)> _
    Public Property ComboBoxPosition() As Integer
        Get
            Return m_ComboboxPosition
        End Get
        Set(value As Integer)
            m_ComboboxPosition = value
        End Set
    End Property

    Public Function getIDFromPosition() As Integer



    End Function

End Class
