
#ifndef _RD_RENDERER_DX11_H_
#define _RD_RENDERER_DX11_H_

#include "RD_Renderer.h"
#include "PL_Configure.h"

#if defined(SUPPORT_RENDERER_DX11)

/*!
 *  @class RD_RendererDX11
 *  DirectX 11 specific renderer.
 */
class RD_RendererDX11 : public RD_Renderer
{
public:

  RD_RendererDX11();
  virtual ~RD_RendererDX11();

  virtual void initialize();
  virtual void shutdown();

  virtual void setDevice( void *device, int eventType );

  virtual void cleanup();

  virtual void beginRender();
  virtual void endRender();

  virtual void setMatrices( const Math::Matrix4x4 &projectionMatrix, const Math::Matrix4x4 &modelViewMatrix );

  virtual void beginSpriteSheet( const RD_SpriteSheetPtr_t &spriteSheet );
  virtual void endSpriteSheet();

  virtual void beginComposition( const RD_RenderScriptPlainPtr_t &renderScript );
  virtual void endComposition( const RD_RenderScriptPlainPtr_t &renderScript );

  virtual void beginComposition( const RD_RenderScriptFxPtr_t &renderScript );
  virtual void endComposition( const RD_RenderScriptFxPtr_t &renderScript );

  virtual void beginBatch( const RD_RenderScriptFx::RenderBatch &renderBatch );
  virtual void endBatch( const RD_RenderScriptFx::RenderBatch &renderBatch );

  virtual void renderScriptToTexture( const RD_RenderScriptPtr_t &pRenderScript, const Rect &rect, float scale, TexturePtr_t texture );
  virtual void renderScript( const RD_RenderScriptPtr_t &pRenderScript, const Math::Matrix4x4 &projectionMatrix, const Math::Matrix4x4 &modelViewMatrix );

  virtual void renderVertices( unsigned short *indices, unsigned indexOffset, unsigned nIndices, unsigned vertexOffset, unsigned nVertices );
  virtual void renderVertices( unsigned int   *indices, unsigned indexOffset, unsigned nIndices, unsigned vertexOffset, unsigned nVertices );

protected:

  void cleanupPriv( bool forceCleanup );

private:

  class Impl;
  Impl *_i;
};

#endif /* SUPPORT_RENDERER_DX11 */

#endif /* _RD_RENDERER_DX11_H_ */