#include <stdio.h>
#include <stdlib.h>
#include <WinSock2.h>
#include "Client.h"

#pragma comment(lib, "wsock32.lib")

WSADATA wsadata;
SOCKET sock;
sockaddr_in addr;

bool __stdcall setup()
{
	if (WSAStartup(MAKEWORD(2, 0), &wsadata))
		return false;

	if ((sock = socket(AF_INET, SOCK_DGRAM, 0)) == INVALID_SOCKET)
		return false;

	addr.sin_family = AF_INET;
	addr.sin_port = htons(12345);
	addr.sin_addr.S_un.S_addr = INADDR_ANY;

	if (bind(sock, (sockaddr*)&addr, sizeof(addr)) == SOCKET_ERROR)
		return false;

	return true;
}

int __stdcall update()
{
	char buf[32];
	memset(buf, 0, sizeof(buf));
	recv(sock, buf, sizeof(buf), 0);
	return atoi(buf);
}

void __stdcall close()
{
	closesocket(sock);
	WSACleanup();
}