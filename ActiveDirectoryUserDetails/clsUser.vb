Public Class clsUser

    Private m_UserName As String
    Public Property UserName() As String
        Get
            Return m_UserName
        End Get
        Set(ByVal value As String)
            m_UserName = value
        End Set
    End Property

    Private m_UserFullName As String
    Public Property UserFullName() As String
        Get
            Return m_UserFullName
        End Get
        Set(ByVal value As String)
            m_UserFullName = value
        End Set
    End Property

    Private m_AccountActive As Boolean
    Public Property AccountActive() As Boolean
        Get
            Return m_AccountActive
        End Get
        Set(ByVal value As Boolean)
            m_AccountActive = value
        End Set
    End Property

    Private m_AccountExpired As Boolean
    Public Property AccountExpired() As Boolean
        Get
            Return m_AccountExpired
        End Get
        Set(ByVal value As Boolean)
            m_AccountExpired = value
        End Set
    End Property

    Private m_AccountLocked As Boolean
    Public Property AccountLocked() As Boolean
        Get
            Return m_AccountLocked
        End Get
        Set(ByVal value As Boolean)
            m_AccountLocked = value
        End Set
    End Property

    Private m_PasswordExpired As Boolean
    Public Property PasswordExpired() As Boolean
        Get
            Return m_PasswordExpired
        End Get
        Set(ByVal value As Boolean)
            m_PasswordExpired = value
        End Set
    End Property

    Public Sub ClearUserDetails()

        UserName = ""
        UserFullName = ""
        AccountActive = Nothing
        AccountExpired = Nothing
        AccountLocked = Nothing
        PasswordExpired = Nothing

    End Sub

End Class
