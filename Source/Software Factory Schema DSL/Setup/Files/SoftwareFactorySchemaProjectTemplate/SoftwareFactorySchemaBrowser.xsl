<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
		<head>
			<title>Software Factory Schema Browser</title>
			<link rel="StyleSheet" href="style.css" TYPE="text/css" />
		</head>
      <body>
        <h1 id="top">Software Factory Schema Browser</h1>
		  <table border="0">
		  <table border="1" cellspacing="0" width="100%">
			  <tr height="80px">
				  <th align="center" width="100px">
					  <h2 style="text-align: center">
						  <a href="#ViewPoints">ViewPoints</a>
					  </h2>
				  </th>
				  <th align="center" width="100px">
					  <h2 style="text-align: center">
						  <a href="#Activities">Activities</a>
					  </h2>
				  </th>
				  <th aligh="center" width="100px">
					  <h2 style="text-align: center">
						  <a href="#Stakeholders">Stakeholders</a>
					  </h2>
				  </th>
				  <th aligh="center" width="100px">
					  <h2 style="text-align: center">
						  <a href="#Artifacts">Artifacts</a>
					  </h2>
				  </th>
				  <th aligh="center" width="100px">
					  <h2 style="text-align: center">
						  <a href="#Mappings">Mappings</a>
					  </h2>
				  </th>
			  </tr>
			  <tr style="text-align: left">
				  <td colspan="5" id="Viewpoints">
					  <h3 style="text-align: right">
						  <a href="#top">back to top</a>
					  </h3>
					  <h2>Viewpoints</h2>
					  <ul>
						  <xsl:for-each select="SFSchema/ViewPoints/ViewPoint">
							  <xsl:variable name="ViewPointID">
								  <xsl:value-of select="@ID"/>
							  </xsl:variable>
							  <li>
								  <a href="#{$ViewPointID}">
									  <xsl:value-of select="@name"/>
								  </a>
							  </li>
						  </xsl:for-each>
					  </ul>
				  </td>
			  </tr>
			  <tr style="text-align: left">
				  <td colspan="5" id="Activities">
					  <h3 style="text-align: right">
						  <a href="#top">back to top</a>
					  </h3>
					  <h2>Activities</h2>
					  <ul>
						  <xsl:for-each select="SFSchema/Activities/Activity">
							  <xsl:variable name="ActivityID">
								  <xsl:value-of select="@ID"/>
							  </xsl:variable>
							  <li>
								  <a href="#{$ActivityID}">
									  <xsl:value-of select="@name"/>
								  </a>
							  </li>
						  </xsl:for-each>
					  </ul>
				  </td>
			  </tr>
			  <tr style="text-align: left">
				  <td colspan="5" id="Stakeholders">
					  <h3 style="text-align: right">
						  <a href="#top">back to top</a>
					  </h3>
					  <h2>Stakeholders</h2>
					  <ul>
						  <xsl:for-each select="SFSchema/Stakeholders/Stakeholder">
							  <xsl:variable name="StakeholderName">
								  <xsl:value-of select="@name"/>
							  </xsl:variable>
							  <li>
								  <a href="#{$StakeholderName}">
									  <xsl:value-of select="@name"/>
								  </a>
							  </li>
						  </xsl:for-each>
					  </ul>
				  </td>
			  </tr>
			  <tr style="text-align: left">
				  <td colspan="5" id="Artifacts">
					  <h3 style="text-align: right">
						  <a href="#top">back to top</a>
					  </h3>
					  <h2>Artifacts</h2>
					  <em>Assets:</em>
					  <ul>
						  <xsl:for-each select="/SFSchema/Artifacts/Artifact">
							  <xsl:if test="@type = 'Asset'">
								  <xsl:variable name="ArtifactID">
									  <xsl:value-of select="@ID"/>
								  </xsl:variable>
								  <li>
									  <a href="#{$ArtifactID}">
										  <xsl:value-of select="@name"/>
									  </a>
								  </li>
							  </xsl:if>
						  </xsl:for-each>
					  </ul>
					  <br/>
					  <br/>
					  <em>Tools:</em>
					  <ul>
						  <xsl:for-each select="/SFSchema/Artifacts/Artifact">
							  <xsl:if test="@type = 'Tool'">
								  <xsl:variable name="ArtifactID">
									  <xsl:value-of select="@ID"/>
								  </xsl:variable>
								  <li>
									  <a href="#{$ArtifactID}">
										  <xsl:value-of select="@name"/>
									  </a>
								  </li>
							  </xsl:if>
						  </xsl:for-each>
					  </ul>
					  <br/>
					  <br/>
					  <em>WorkProducts:</em>
					  <ul>
						  <xsl:for-each select="/SFSchema/Artifacts/Artifact">
							  <xsl:if test="@type = 'WorkProduct'">
								  <xsl:variable name="ArtifactID">
									  <xsl:value-of select="@ID"/>
								  </xsl:variable>
								  <li>
									  <a href="#{$ArtifactID}">
										  <xsl:value-of select="@name"/>
									  </a>
								  </li>
							  </xsl:if>
						  </xsl:for-each>
					  </ul>
					  <br/>
				  </td>
			  </tr>
			  <tr style="text-align: left">
				  <td colspan="5" id="Mappings">
					  <h3 style="text-align: right">
						  <a href="#top">back to top</a>
					  </h3>
					  <h2>Mappings</h2>
					  <ul>
						  <xsl:for-each select="SFSchema/Mappings/Mapping">
							  <xsl:variable name="MappingID">
								  <xsl:value-of select="@ID"/>
							  </xsl:variable>
							  <li>
								  <a href="#{$MappingID}">
									  <xsl:value-of select="@name"/>
								  </a>
							  </li>
						  </xsl:for-each>
					  </ul>
				  </td>
			  </tr>
			  
		  </table>
		  <p> </p>
		  <table border="1" cellspacing="0" width="100%">
			  <tr height="80px">
				  <th align="center" width="100px">
					  <h2 style="text-align: center">
						  <a href="#Activities">Viewpoints</a>
					  </h2>
				  </th>
			  </tr>
			  
          <xsl:for-each select="SFSchema/ViewPoints/ViewPoint">
            <xsl:variable name="ViewPointID">
              <xsl:value-of select="@ID"/>
            </xsl:variable>
            <tr style="text-align: left">
              <td colspan="5" id="{$ViewPointID}">
                <h3 style="text-align: right">
                  <a href="#top">back to top</a>
                </h3>
                <h2>Viewpoint "<xsl:value-of select="@name"/>"</h2>
                <em>Stakeholders interested in this Viewpoint:</em>
                <xsl:for-each select="Stakeholders/Stakeholder">
                  <xsl:variable name="StakeholderName">
                    <xsl:value-of select="@name"/>
                  </xsl:variable>
                  <li>
                    <a href="#{$StakeholderName}"><xsl:value-of select="@name"/></a>
                  </li>
                </xsl:for-each>
                <br/>
                <br/>
                <em>Activities within in this Viewpoint:</em>
                <xsl:for-each select="Activity">
                  <xsl:variable name="ActivityID">
                    <xsl:value-of select="@ID"/>
                  </xsl:variable>
                  <xsl:variable name="ActivityName">
                    <xsl:for-each select="/SFSchema/Activities/Activity">
                      <xsl:if test="@ID = $ActivityID">
                        <xsl:value-of select="@name"/>
                      </xsl:if>
                    </xsl:for-each>
                  </xsl:variable>
                  <li>
                    <a href="#{$ActivityID}">
                      <xsl:value-of select="$ActivityName"/>
                    </a>
                  </li>
                </xsl:for-each>
                <br/>
                <br/>
                <em>Artifacts within in this Viewpoint:</em>
                <xsl:for-each select="Artifact">
                  <xsl:variable name="ArtifactID">
                    <xsl:value-of select="@ID"/>
                  </xsl:variable>
                  <xsl:variable name="ArtifactName">
                    <xsl:for-each select="/SFSchema/Artifacts/Artifact">
                      <xsl:if test="@ID = $ArtifactID">
                        <xsl:value-of select="@name"/>
                      </xsl:if>
                    </xsl:for-each>
                  </xsl:variable>
                  <xsl:variable name="ArtifactType">
                    <xsl:for-each select="/SFSchema/Artifacts/Artifact">
                      <xsl:if test="@ID = $ArtifactID">
                        <xsl:value-of select="@type"/>
                      </xsl:if>
                    </xsl:for-each>
                  </xsl:variable>
                  <li>
                    <xsl:value-of select="$ArtifactType"/>: <a href="#{$ArtifactID}"><xsl:value-of select="$ArtifactName"/></a>
                  </li>
                </xsl:for-each>
                <br/>
                <br/>
              </td>
            </tr>
          </xsl:for-each>
			  
		  </table>
		  <p> </p>
		  <table border="1" cellspacing="0" width="100%">
			  <tr height="80px">
				  <th align="center" width="100px">
					  <h2 style="text-align: center">
						  <a href="#Activities">Activities</a>
					  </h2>
				  </th>
			  </tr>

			  <xsl:for-each select="SFSchema/Activities/Activity">
            <xsl:variable name="ActivityID">
              <xsl:value-of select="@ID"/>
            </xsl:variable>
            <tr style="text-align: left">
              <td colspan="5" id="{$ActivityID}">
                <h3 style="text-align: right">
                  <a href="#top">back to top</a>
                </h3>
                <h2>
                  Activity "<xsl:value-of select="@name"/>"
                </h2>
                <xsl:for-each select="//ViewPoint/Activity">
                  <xsl:if test="@ID = $ActivityID">

                    <xsl:if test="Uses/Artifact">
                      <em>uses:</em>
                      <xsl:for-each select="Uses/Artifact">
                        <xsl:variable name="ArtifactID">
                          <xsl:value-of select="@ID"/>
                        </xsl:variable>
                        <xsl:variable name="ArtifactName">
                          <xsl:for-each select="/SFSchema/Artifacts/Artifact">
                            <xsl:if test="@ID = $ArtifactID">
                              <xsl:value-of select="@name"/>
                            </xsl:if>
                          </xsl:for-each>
                        </xsl:variable>
                        <xsl:variable name="ArtifactType">
                          <xsl:for-each select="/SFSchema/Artifacts/Artifact">
                            <xsl:if test="@ID = $ArtifactID">
                              <xsl:value-of select="@type"/>
                            </xsl:if>
                          </xsl:for-each>
                        </xsl:variable>
                        <li>
                          <a href="#{$ArtifactID}">
                            <xsl:value-of select="$ArtifactName"/>
                          </a> (<xsl:value-of select="$ArtifactType"/>)
                        </li>
                      </xsl:for-each>
                      <br/>
                      <br/>
                    </xsl:if>
                    <xsl:if test="Writes/Artifact">
                      <em>writes:</em>
                      <xsl:for-each select="Writes/Artifact">
                        <xsl:variable name="ArtifactID">
                          <xsl:value-of select="@ID"/>
                        </xsl:variable>
                        <xsl:variable name="ArtifactName">
                          <xsl:for-each select="/SFSchema/Artifacts/Artifact">
                            <xsl:if test="@ID = $ArtifactID">
                              <xsl:value-of select="@name"/>
                            </xsl:if>
                          </xsl:for-each>
                        </xsl:variable>
                        <xsl:variable name="ArtifactType">
                          <xsl:for-each select="/SFSchema/Artifacts/Artifact">
                            <xsl:if test="@ID = $ArtifactID">
                              <xsl:value-of select="@type"/>
                            </xsl:if>
                          </xsl:for-each>
                        </xsl:variable>
                        <li>
                          <a href="#{$ArtifactID}"><xsl:value-of select="$ArtifactName"/></a> (<xsl:value-of select="$ArtifactType"/>)
                        </li>
                      </xsl:for-each>
                      <br/>
                      <br/>
                    </xsl:if>
                  </xsl:if>
                </xsl:for-each>
              </td>
            </tr>
          </xsl:for-each>

		  </table>
		  <p> </p>
		  <table border="1" cellspacing="0" width="100%">
			  <tr height="80px">
				  <th align="center" width="100px">
					  <h2 style="text-align: center">
						  <a href="#Activities">Artifacts</a>
					  </h2>
				  </th>
			  </tr>

			  <xsl:for-each select="SFSchema/Artifacts/Artifact">
            <xsl:variable name="ArtifactID">
              <xsl:value-of select="@ID"/>
            </xsl:variable>
            <xsl:variable name="ArtifactType">
              <xsl:value-of select="@type"/>
            </xsl:variable>
            <xsl:variable name="ArtifactName">
              <xsl:value-of select="@name"/>
            </xsl:variable>
            <tr style="text-align: left">
              <td colspan="5" id="{$ArtifactID}">
                <xsl:if test="$ArtifactType = 'Asset'">
                  <h3 style="text-align: right">
                    <a href="#top">back to top</a>
                  </h3>
                  <h2>
                    Asset "<xsl:value-of select="@name"/>" 
                  </h2>
                </xsl:if>
                <xsl:if test="$ArtifactType = 'Tool'">
                  <h3 style="text-align: right">
                    <a href="#top">back to top</a>
                  </h3>
                  <h2>
                    Tool "<xsl:value-of select="@name"/>" 
                  </h2>
                </xsl:if>
                <xsl:if test="$ArtifactType = 'WorkProduct'">
                  <h3 style="text-align: right">
                    <a href="#top">back to top</a>
                  </h3>
                  <h2>
                    WorkProduct "<xsl:value-of select="@name"/>"
                  </h2>
                </xsl:if>
                <br/>
                <xsl:for-each select="/SFSchema/ViewPoints/ViewPoint">
                  <xsl:variable name="ViewPointName">
                    <xsl:value-of select="@name"/>
                  </xsl:variable>
                  <xsl:variable name="ViewPointID">
                    <xsl:value-of select="@ID"/>
                  </xsl:variable>
                  <xsl:for-each select="Artifact">
                    <xsl:if test="@ID = $ArtifactID">
                      <li>
                        filtered by ViewPoint "<a href="#{$ViewPointID}"><xsl:value-of select="$ViewPointName"/>"</a>
                      </li>
                    </xsl:if>
                  </xsl:for-each>
                </xsl:for-each>

                <xsl:for-each select="/SFSchema/ViewPoints/ViewPoint">
                  <xsl:for-each select="Activity">
                    <xsl:variable name="ActivityID">
                      <xsl:value-of select="@ID"/>
                    </xsl:variable>
                    <xsl:for-each select="Uses/Artifact">
                      <xsl:if test="@ID = $ArtifactID">
                        <li>
                          <xsl:for-each select="/SFSchema/Activities/Activity">
                            <xsl:if test="@ID = $ActivityID">
                              used by Activity "<a href="#{$ActivityID}"><xsl:value-of select="@name"/></a>"
                            </xsl:if>
                          </xsl:for-each>
                        </li>
                      </xsl:if>
                    </xsl:for-each>
                    <xsl:for-each select="Writes/Artifact">
                      <xsl:if test="@ID = $ArtifactID">
                        <li>
                          <xsl:for-each select="/SFSchema/Activities/Activity">
                            <xsl:if test="@ID = $ActivityID">
                              created/modified by Activity "<a href="#{$ActivityID}"><xsl:value-of select="@name"/>"</a>
                            </xsl:if>
                          </xsl:for-each>
                        </li>
                      </xsl:if>
                    </xsl:for-each>
                  </xsl:for-each>
                </xsl:for-each>
                <br/>
                <br/>
              </td>
            </tr>
          </xsl:for-each>

		  </table>
		  <p> </p>
		  <table border="1" cellspacing="0" width="100%">
			  <tr height="80px">
				  <th align="center" width="100px">
					  <h2 style="text-align: center">
						  <a href="#Activities">Stakeholders</a>
					  </h2>
				  </th>
			  </tr>

		  <xsl:for-each select="SFSchema/Stakeholders/Stakeholder">
            <xsl:variable name="StakeholderName">
              <xsl:value-of select="@name"/>
            </xsl:variable>
            <tr style="text-align: left">
              <td colspan="5" id="{$StakeholderName}">
                
                  <h3 style="text-align: right">
                    <a href="#top">back to top</a>
                  </h3>
                  <h2>
                    Stakeholder "<xsl:value-of select="$StakeholderName"/>" is interested in
                  </h2>
                
                <br/>
                <xsl:for-each select="/SFSchema/ViewPoints/ViewPoint">
                  <xsl:variable name="ViewPointName">
                    <xsl:value-of select="@name"/>
                  </xsl:variable>
                  <xsl:variable name="ViewPointID">
                    <xsl:value-of select="@ID"/>
                  </xsl:variable>
                  <xsl:for-each select="Stakeholders/Stakeholder">
                    <xsl:if test="@name = $StakeholderName">
                      <li>
                        ViewPoint <a href="#{$ViewPointName}"><xsl:value-of select="$ViewPointName"/></a>
                      </li>
                    </xsl:if>
                  </xsl:for-each>
                </xsl:for-each>
                <br/>
                <br/>
              </td>
            </tr>
          </xsl:for-each>

		  </table>
		  <p> </p>
		  <table border="1" cellspacing="0" width="100%">
			  <tr height="80px">
				  <th align="center" width="100px">
					  <h2 style="text-align: center">
						  <a href="#Activities">Mappings</a>
					  </h2>
				  </th>
			  </tr>

			  <xsl:for-each select="SFSchema/Mappings/Mapping">
            <xsl:variable name="MappingID">
              <xsl:value-of select="@ID"/>
            </xsl:variable>
            <xsl:variable name="MappingSourceID">
              <xsl:value-of select="@source"/>
            </xsl:variable>
            <xsl:variable name="MappingTargetID">
              <xsl:value-of select="@target"/>
            </xsl:variable>
            <xsl:variable name="MappingBidirectional">
              <xsl:value-of select="@bidirectional"/>
            </xsl:variable>
            <tr style="text-align: left">
              <td colspan="5" id="{$MappingID}">
                <xsl:if test="$MappingBidirectional = 'true'">
                  <h3 style="text-align: right">
                    <a href="#top">back to top</a>
                  </h3>
                  <h2>
                    Mapping "<xsl:value-of select="@name"/>" (Bidirectional)
                  </h2>
                </xsl:if>
                <xsl:if test="$MappingBidirectional = 'false'">
                  <h3 style="text-align: right">
                    <a href="#top">back to top</a>
                  </h3>
                  <h2>
                    Mapping "<xsl:value-of select="@name"/>"
                  </h2>
                </xsl:if>
                <br/>
                Description:
                <br/>
                <em>
                  <xsl:value-of select="Description"/>
                </em>  
                <xsl:for-each select="/SFSchema/ViewPoints/ViewPoint">
                  <xsl:if test="@ID = $MappingSourceID">
                    <li>
                      Source: <a href="#{$MappingSourceID}"><xsl:value-of select="@name"/></a>
                    </li>
                  </xsl:if>
                  <xsl:if test="@ID = $MappingTargetID">
                    <li>
                      Target: <a href="#{$MappingTargetID}"><xsl:value-of select="@name"/></a>
                    </li>
                  </xsl:if>
                </xsl:for-each>
                <br/>
                <br/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
		</table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>