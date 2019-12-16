  pipeline{
    agent any
    
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
               git credentialsId:'1f8d84f63bd5d7b56a7930068a148c494a5adcd6', url:'https://github.com/HansikaW/Rambase/', branch:'IntegrationTesting'\
            }
        }
        
        stage('Restore packages'){
            steps{
               bat "dotnet restore WebApplicationTest\\WebApplicationTest\\WebApplicationTest.csproj"
               bat "dotnet restore WebApplicationTest\\testIntegration\\testIntegration.csproj"
            }
        }
        
        stage('Clean'){
            steps{
                bat "dotnet clean WebApplicationTest\\WebApplicationTest\\WebApplicationTest.csproj"
                bat "dotnet clean WebApplicationTest\\testIntegration\\testIntegration.csproj"
            }
        }
        
        stage('Build'){
            steps{
                bat "dotnet build WebApplicationTest\\WebApplicationTest\\WebApplicationTest.csproj --configuration Release"
                bat "dotnet build WebApplicationTest\\testIntegration\\testIntegration.csproj --configuration Release"
            }    
        }
        
       stage('SonarQube analysis') {
         steps{
            bat "dotnet sonarscanner begin /k:Hatteland-POC /d:sonar.login=admin /d:sonar.password=admin"
            bat "dotnet build WebApplicationTest\\WebApplicationTest\\WebApplicationTest.csproj --configuration Release"
            bat "dotnet build WebApplicationTest\\testIntegration\\testIntegration.csproj --configuration Release"
            bat "dotnet sonarscanner end /d:sonar.login=admin /d:sonar.password=admin" 
          }
        }
        
        stage('Test: Integration Test'){
            steps {
               bat "dotnet test WebApplicationTest\\testIntegration\\testIntegration.csproj"
           }
        }
       
         stage('Publish'){
            steps{
               bat "dotnet publish WebApplicationTest\\WebApplicationTest\\WebApplicationTest.csproj"
               bat "dotnet publish WebApplicationTest\\testIntegration\\testIntegration.csproj"
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
