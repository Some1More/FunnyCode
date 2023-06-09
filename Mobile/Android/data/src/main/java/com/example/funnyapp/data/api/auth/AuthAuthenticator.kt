package com.example.funnyapp.data.api.auth

import com.example.funnyapp.data.model.response.AuthInfo
import kotlinx.coroutines.flow.first
import kotlinx.coroutines.runBlocking
import okhttp3.Authenticator
import okhttp3.Request
import okhttp3.Response
import okhttp3.Route
import retrofit2.Call

class AuthAuthenticator(private val tokenManager: TokenManager) : Authenticator {
    override fun authenticate(route: Route?, response: Response): Request? {
        val token = runBlocking {
            tokenManager.getRefreshToken().first()
        }
        return runBlocking {
            val newToken = getNewToken(refreshToken = token).execute()

            if (!newToken.isSuccessful || newToken.body() == null)
                tokenManager.deleteToken()

            newToken.body()?.let {
                tokenManager.saveTokens(
                    token = it.accessToken,
                    refreshToken = it.refreshToken
                )
                response.request.newBuilder()
                    .header("Authorization", "Bearer ${it.accessToken}")
                    .build()
            }
        }
    }

    private fun getNewToken(refreshToken: String?): Call<AuthInfo> {
        val apiClient = AuthApiClient().getApiService(tokenManager)
        return apiClient.refreshToken()
    }
}