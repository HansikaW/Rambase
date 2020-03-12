    pipeline{
    agent any
    
    triggers {
        githubPush()
    }

    stages {
        stage('Workspace Cleanup') {
            steps {
                step([$class: 'WsCleanup'])
           }
       }
         
        stage('Checkout') {
            steps {
                git credentialsId:'812ff5ae1a00a11786bc552fa86301750903f3e0', url:'https://github.com/HansikaW/rambase-poc/', branch:'IntegrationTesting'\
            }
        }
        
        stage('Restore packages'){
            steps{
                sh "dotnet restore WebApplicationTest/WebApplicationTest/WebApplicationTest.csproj"
                sh "dotnet restore WebApplicationTest/testIntegration/testIntegration.csproj"
            }
        }
        
        stage('Clean'){
            steps{
                sh "dotnet clean WebApplicationTest/WebApplicationTest/WebApplicationTest.csproj"
                sh "dotnet clean WebApplicationTest/testIntegration/testIntegration.csproj"
            }
        }
        
        stage('Build'){
            steps{
                sh "dotnet build WebApplicationTest/WebApplicationTest/WebApplicationTest.csproj --configuration Release"
                sh "dotnet build WebApplicationTest/testIntegration/testIntegration.csproj --configuration Release"
            }    
        }  
        
        stage('Test: Integration Test'){
            steps {
                sh "dotnet test WebApplicationTest/testIntegration/testIntegration.csproj"
            }
         }      
    }
    
    post{
       always{
           emailext body: "${currentBuild.currentResult}: Job   ${env.JOB_NAME} build ${env.BUILD_NUMBER}\n More info at: ${env.BUILD_URL}",
           recipientProviders: [[$class: 'RequesterRecipientProvider']], to: 'inbox.rajika@gmail.com',
           subject: "Jenkins Build ${currentBuild.currentResult}: Job ${env.JOB_NAME}"
        }
    }
}
