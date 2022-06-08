FROM mcr.microsoft.com/mssql/server:2017-latest

USER root
RUN apt-get -y update 
RUN apt-get -y upgrade
RUN apt-get install -y curl
RUN apt-get install -y dialog apt-utils 
RUN curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add -
RUN curl https://packages.microsoft.com/config/ubuntu/16.04/mssql-server-2017.list | tee /etc/apt/sources.list.d/mssql-server.list 
RUN apt-get -y update 
RUN apt-get install -y mssql-server-fts 

CMD /opt/mssql/bin/sqlservr