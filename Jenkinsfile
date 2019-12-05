  pipeline{
    agent any
    
    tools {nodejs "node"}
    
    environment {
        dotnet ='C:\\Program Files (x86)\\dotnet\\'
        }
    
     triggers {
        githubPush()
    }
    
    stages {
        stage('Git') {
            steps {
                step([$class: 'WsCleanup'])
            }
        }
        
        stage('Checkout') {
           steps {
               git credentialsId:'b96bff92e27abd6a382c38842c103bedd1ab0f66', url:'https://github.com/HansikaW/Rambase/', branch:'master'\
            }
        }
        
        stage('Restore packages'){
            steps{
               bat "dotnet restore server\\WebAPI\\WebAPI.csproj"
               bat "dotnet restore server\\WebAPIIntegrationTestProject\\WebAPIIntegrationTestProject.csproj"
               bat "dotnet restore server\\WebAPITestProject\\WebAPITestProject.csproj"
            }
        }
        
        stage('Clean'){
            steps{
                bat "dotnet clean server\\WebAPI\\WebAPI.csproj"
                bat "dotnet clean server\\WebAPIIntegrationTestProject\\WebAPIIntegrationTestProject.csproj"
                bat "dotnet clean server\\WebAPITestProject\\WebAPITestProject.csproj"
            }
        }
        
        stage('Build'){
            steps{
                bat "dotnet build server\\WebAPI\\WebAPI.csproj --configuration Release"
                bat "dotnet build server\\WebAPIIntegrationTestProject\\WebAPIIntegrationTestProject.csproj --configuration Release"
                bat "dotnet build server\\WebAPITestProject\\WebAPITestProject.csproj --configuration Release"
            }    
        }
        
       stage('SonarQube analysis') {
         steps{
            bat "dotnet sonarscanner begin /k:Hatteland-POC /d:sonar.login=admin /d:sonar.password=admin"
            bat "dotnet build server\\WebAPI\\WebAPI.csproj --configuration Release"
            bat "dotnet build server\\WebAPITestProject\\WebAPITestProject.csproj --configuration Release"
            bat "dotnet sonarscanner end /d:sonar.login=admin /d:sonar.password=admin" 
          }
        }
        
       stage('Test: Unit Test'){
            steps {
               bat "dotnet test server\\WebAPITestProject\\WebAPITestProject.csproj "
            }
       }
         
       stage('Publish'){
            steps{
               bat "dotnet publish server\\WebAPI\\WebAPI.csproj"
               bat "dotnet publish server\\WebAPIIntegrationTestProject\\WebAPIIntegrationTestProject.csproj"
               bat "dotnet publish server\\WebAPITestProject\\WebAPITestProject.csproj"
           }
         }
       }
      
      post{
        always{
         emailext body: "${currentBuild.currentResult}: Job   ${env.JOB_NAME} build ${env.BUILD_NUMBER}\n More info at: ${env.BUILD_URL}",
         recipientProviders: [[$class: 'DevelopersRecipientProvider'], [$class: 'RequesterRecipientProvider']],
         subject: "Jenkins Build ${currentBuild.currentResult}: Job ${env.JOB_NAME}"
      }
    }
  }
