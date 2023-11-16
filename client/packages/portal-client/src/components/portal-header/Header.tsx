import { useMenuContext, useViewController } from '@equinor/portal-core';
import { MenuButton, Header } from '@equinor/portal-ui';

import { useNavigate } from 'react-router-dom';
import { appMounted } from '@portal/core';

export function MainHeader() {
	const { getId, setViewId } = useViewController();
	const navigate = useNavigate();
	useMenuContext();

	const handleLogoClick = () => {
		const id = getId();
		if (appMounted(window.location.pathname) && id) {
			setViewId(id);
		} else {
			setViewId(undefined);
		}
		navigate('/');
	};

	return <Header onLogoClick={handleLogoClick} MenuButton={MenuButton} />;
}

export default MainHeader;
