  pipeline{
    agent any
    
    tools {nodejs "node"}
    
    environment {
        node = 'C:\\Program Files\\nodejs\\'
        }
        
     triggers {
        githubPush()
    }
    
    stages{
        stage('Git') {
            steps {
                step([$class: 'WsCleanup'])
            }
        }
        
    stage('Checkout') {
            steps {
               git credentialsId:'b96bff92e27abd6a382c38842c103bedd1ab0f66', url:'https://github.com/HansikaW/rambase-poc/', branch:'client'\
        }    
    }
    
    stage('Restore packages') {
        steps {
            dir('client') {
               bat "npm install" 
            }
        }
    
     }
     
     stage('Build'){
        steps{
            dir('client') {
               bat"npm build --prod " 
            }
          }
        }
        
    stage('Unit test'){
        steps{
           dir('client') {
              bat "npm run test --code-coverage"
           } 
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
