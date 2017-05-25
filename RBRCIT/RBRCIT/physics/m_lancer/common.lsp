(("PhysicsEngine" 
  DefManager (		 
			
			("CarBody" ("CAR_BODY"
						  vecCenterOfGravity 0 -1.45 0.22))




			   ("Car" ("CAR_ROOT"
					  CarId 3
					  InverseMass     0.000714
					  vecLocalInverseInertiaDiagonal 0.00070 0.00169 0.00071

					  EffWheelRadius  		0.315000
					  

					  MaxSteeringLock		2.35
					  SteeringRackRatio		-0.040
					  
					  FrontArea			2.0
					  DragCoefficient		0.5

					  SubTics	      1

					

					  Drive           ("Drive"
									EngineInertia		0.1
									GearBoxInertiaIn	0.1
									GearBoxInertiaOut	0.01
		
									MaxHandbrakePressure	15000000			
							
									NumberOfGears 	8						
									
									WheelInertia	2.0								
							
									   )
					ControlUnit	("ControlUnit"	
									   
									CenterDiffHandbrakeRelease 0.5
									LeftFootBrakeThreshold 0.2
									   		
									
					
									   )
						
					  iCollisionMesh	1
					  ))

	
				("HingedBody" ("CAR_DOOR_L"

							vecHingeAxis_RF 	 0.0  0.0  1.0	
							vecZeroAxis_RF 		 0.0  1.0  0.0
							vecHingePoint_RF 	 0.826 -2.179  0.378

							vecHingeAxis_BF 	 1.0  0.0  0.0
							vecZeroAxis_BF  	 0.0  1.0  0.0	
							vecHingePoint_BF  	 0.0 -0.5  0.0

							vecFaceNormal_BF	 0.0  0.0  -1.0

							HingeMinAngle		 -2.1
							HingeMaxAngle		 0.01
							HingeDefaultAngle	 0.01

							InverseMass		 0.05
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0
							InertiaHingeAxis	 5.0	

							Sleepable		 1	
					  		SleepDelay		 0.5
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 6.0

							FaceArea		1.0
							
							Spring0Type		2
							Spring0Pos		-0.75	
							Spring0Stiff		5000.0
							Spring0Damp		100.0
							Spring0MaxDisp		0.05
							Spring0Span		0.73

							BodyId			0

						 ))

				("HingedBody" ("CAR_DOOR_R"

							vecHingeAxis_RF 	 0.0  0.0  -1.0	
							vecZeroAxis_RF 		 0.0  1.0  0.0
							vecHingePoint_RF 	 -0.826 -2.179  0.378

							vecHingeAxis_BF 	 1.0  0.0  0.0
							vecZeroAxis_BF  	 0.0  1.0  0.0	
							vecHingePoint_BF  	 0.0 -0.5  0.0
							vecFaceNormal_BF	 0.0  0.0  -1.0

							HingeMinAngle		 -2.1
							HingeMaxAngle		 0.01
							HingeDefaultAngle	 0.01

							InverseMass		 0.05
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0
							
							InertiaHingeAxis	 5.0	

							Sleepable		 1	
					  		SleepDelay		 0.5
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 6.0

							FaceArea		1.0
							
							Spring0Type		2
							Spring0Pos		-0.75	
							Spring0Stiff		5000.0
							Spring0Damp		100.0
							Spring0MaxDisp		0.05
							Spring0Span		0.73

							BodyId			1
						 ))

				("HingedBody" ("CAR_BONNET"

							vecHingeAxis_RF 	 1.0  0.0  0.0	
							vecZeroAxis_RF 		 0.0  1.0  0.0
							vecHingePoint_RF 	 0.732 -2.265  0.717

							vecHingeAxis_BF 	 1.0  0.0  0.0
							vecZeroAxis_BF  	 0.0  1.0  0.0	
							vecHingePoint_BF  	 0.35  0.3  0.0
							vecFaceNormal_BF	 0.0  -0.45  -0.83939

							HingeMinAngle		 -1.5
							HingeMaxAngle		 -0.0
							HingeDefaultAngle	 -0.0

							InverseMass		 0.2
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0

							InertiaHingeAxis	 1.5

							FaceArea		2.0

							Spring0Type		2
							Spring0Pos		-1.05	
							Spring0Stiff		2000.0
							Spring0Damp		20.0
							Spring0MaxDisp		0.07
							Spring0Span		1.00

							Sleepable		 1	
					  		SleepDelay		 2.0
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 1.0	

							BodyId			2
						 ))

				("HingedBody" ("CAR_EXHAUSTPIPE"

							vecHingeAxis_RF 	 1.0  0.0  0.0	
							vecZeroAxis_RF 		 0.0  1.0  0.0
							vecHingePoint_RF 	 -0.248  0.084  0.13

							vecHingeAxis_BF 	 1.0  0.0  0.0
							vecZeroAxis_BF  	 0.0  1.0  0.0	
							vecHingePoint_BF  	 0.0  -0.3  0.0
							
							HingeMinAngle		 -0.8
							HingeMaxAngle		 +0.05
							HingeDefaultAngle	 +0.05

							InverseMass		 0.2
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0
							InertiaHingeAxis	 1.5	

							Spring0Type		2
							Spring0Pos		0.05	
							Spring0Stiff		9000.0
							Spring0Damp		150.0
							Spring0MaxDisp		0.5
							Spring0Span		0.03

							Sleepable		 1	
					  		SleepDelay		 2.0
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 1.0	

								
							Unlocked		 1

							BreakChain		 1	

							BodyId			3

						 ))

				("MountedBody" ("CAR_BUMPER_F"

							vecBasePoint_PRF	0.0 -3.156 0.220
							InverseMass		 0.2
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0

							
							Sleepable		 1	
					  		SleepDelay		 0.5
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 6.0

							BodyId			0

	

						 ))


				("MountedBody" ("CAR_BUMPER_B"

							vecBasePoint_PRF	0.0 0.554 0.288
							InverseMass		 0.2
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0

							
							Sleepable		 1	
					  		SleepDelay		 0.5
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 6.0

							BodyId			1

	

						 ))


				("MountedBody" ("CAR_WING"

							vecBasePoint_PRF	0.0 0.641 0.910
							InverseMass		 0.2
							vecLocalInverseInertiaDiagonal	1.0 1.0 1.0

							
							Sleepable		 1	
					  		SleepDelay		 0.5
					  		LinearSleepVelocity	 0.5
					  		AngularSleepVelocity	 6.0

							BodyId			2
	

						 ))



			  
)))
