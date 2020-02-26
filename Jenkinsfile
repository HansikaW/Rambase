pipeline{
    agent any
    
    stages {
        stage('Workspace Cleanup') {
            steps {
                step([$class: 'WsCleanup'])
        }
    }
        
    stage('Checkout') {
        steps {
            git credentialsId:'812ff5ae1a00a11786bc552fa86301750903f3e0', url:'https://github.com/HansikaW/rambase-poc/', branch:'client'\
        }
    }
        
    stage('Restore packages'){
        steps{
           sh "dotnet restore server/WebAPI/WebAPI.csproj"
           sh "dotnet restore server/WebAPIIntegrationTestProject/WebAPIIntegrationTestProject.csproj"
           sh "dotnet restore server/WebAPITestProject/WebAPITestProject.csproj"
           sh "dotnet restore WebApplicationTest/WebApplicationTest/WebApplicationTest.csproj"
           sh "dotnet restore WebApplicationTest/testIntegration/testIntegration.csproj"
        }
    }
        
    stage('Clean'){
        steps{
            sh "dotnet clean server/WebAPI/WebAPI.csproj"
            sh "dotnet clean server/WebAPIIntegrationTestProject/WebAPIIntegrationTestProject.csproj"
            sh "dotnet clean server/WebAPITestProject/WebAPITestProject.csproj"
            sh "dotnet clean WebApplicationTest/WebApplicationTest/WebApplicationTest.csproj"
            sh "dotnet clean WebApplicationTest/testIntegration/testIntegration.csproj"
        }
    }
        
    stage('Build'){
        steps{
            sh "dotnet build server/WebAPI/WebAPI.csproj --configuration Release"
            sh "dotnet build server/WebAPIIntegrationTestProject/WebAPIIntegrationTestProject.csproj --configuration Release"
            sh "dotnet build server/WebAPITestProject/WebAPITestProject.csproj --configuration Release"
            sh "dotnet build WebApplicationTest/WebApplicationTest/WebApplicationTest.csproj --configuration Release"
            sh "dotnet build WebApplicationTest/testIntegration/testIntegration.csproj --configuration Release"
        }    
    }
        
   stage('SonarQube analysis') {
       environment {
            PATH = "$PATH:${HOME}/.dotnet/tools"
        }
       steps{
            sh "whoami"
            sh "echo $PATH"
            sh 'dotnet sonarscanner begin /k:Hatteland-POC /d:sonar.host.url="http://168.62.39.23:9000" /d:sonar.login=admin /d:sonar.password=admin'
            sh "dotnet build server/WebAPI/WebAPI.csproj --configuration Release"
            sh "dotnet build server/WebAPITestProject/WebAPITestProject.csproj --configuration Release"
            sh "dotnet sonarscanner end /d:sonar.login=admin /d:sonar.password=admin" 
       }
    }
       
    stage('Test: Unit Test'){
        steps {
           sh "dotnet test server/WebAPITestProject/WebAPITestProject.csproj "
        }
    }
        
    stage('Test: Integration Test'){
        steps {
           sh "dotnet test WebApplicationTest/testIntegration/testIntegration.csproj"
       }
    }
    
    stage('Publish'){
      steps{
        script{
         dir('server/WebAPI') {
            sh "docker login -u hansikaw -p sicasica"  
            sh "docker build -t hattelandserver ."
            sh "docker tag hattelandserver hansikaw/hattelandserver:1.0"
            sh "docker push hansikaw/hattelandserver:1.0"
         }
       }
      } 
    }
    
    /*stage('Test Env: Deploy') {
        steps{
           sh "cp -v /var/jenkins_home/workspace/Test/docker-compose.yml /var/jenkins_home/workspace/Test@tmp"    
           sh "docker-compose up"
       }
    } */
      
    stage('Sanity check') {
        steps {
            input "Does the staging environment look ok?"
        }
      }
    }
    
    post{
       always{
           emailext body: "${currentBuild.currentResult}: Job   ${env.JOB_NAME} build ${env.BUILD_NUMBER}\n More info at: ${env.BUILD_URL}",
           recipientProviders: [[$class: 'RequesterRecipientProvider']], to: 'hansijw76@gmail.com',
           subject: "Jenkins Build ${currentBuild.currentResult}: Job ${env.JOB_NAME}"
        }
      }
    }
